# .NET MAUI + Web API 学習ロードマップ

## 旅行管理アプリを題材とした実践学習

### 学習方針

この学習では、旅行管理アプリを実際に作りながら、

- .NET MAUI
- MVVM
- DI
- Service / Repository
- SQLite
- ASP.NET Core Web API
- MariaDB
- マルチプラットフォーム対応

を段階的に学習する。

ただし、**先に高度なアーキテクチャを作ることを目的としない。**

まず.NET MAUIそのものを理解し、その後にDI・Web API・DBなどを組み合わせていく。

---

# 第1段階：.NET MAUI基礎

## 1-1. MAUIプロジェクトの構造

### 学習項目

- `.csproj`
- `MauiProgram.cs`
- `App.xaml`
- `App.xaml.cs`
- `AppShell.xaml`
- `AppShell.xaml.cs`
- `Platforms`
- `Resources`
- `Properties`

### 到達目標

以下について、それぞれの役割を説明できる。

- MauiProgramとは何か
- Appとは何か
- AppShellとは何か
- Platformsとは何か
- Resourcesとは何か

---

# 1-2. XAML基礎

### 学習項目

- `ContentPage`
- `VerticalStackLayout`
- `HorizontalStackLayout`
- `Grid`
- `Label`
- `Entry`
- `Button`
- `CollectionView`
- `ScrollView`
- 各種レイアウトプロパティ
- `Margin`
- `Padding`
- `Spacing`
- `HorizontalOptions`
- `VerticalOptions`

### 到達目標

簡単な画面なら、ドキュメントを確認しながら自力で作れる。

---

# 1-3. Data Binding

### 学習項目

- Binding
- `Path`
- `Mode=TwoWay`
- `INotifyPropertyChanged`
- `PropertyChanged`
- `SetProperty`
- BindingContext
- `x:DataType`
- Compiled Binding

### 実践

顧客マスタ登録画面で、

- 顧客コード
- 顧客名
- メールアドレス
- メッセージ

をViewModelとBindingする。

### 到達目標

以下の流れを説明できる。

```text
Entry
 ↓
Binding
 ↓
ViewModelのProperty
 ↓
INotifyPropertyChanged
 ↓
画面更新
```

---

# 1-4. Command

### 学習①：自作実装

CommunityToolkit.Mvvmを使わず、

- `ICommand`
- `RelayCommand`
- `CanExecute`
- `CanExecuteChanged`
- `RaiseCanExecuteChanged`

を自分で実装する。

### 学習②：CommunityToolkit.Mvvm

その後、

- `ObservableObject`
- `[ObservableProperty]`
- `[RelayCommand]`
- `[NotifyCanExecuteChangedFor]`

に置き換える。

### 比較する

```text
自作
INotifyPropertyChanged
        ↓
SetProperty
        ↓
RelayCommand
        ↓
RaiseCanExecuteChanged
```

と、

```text
CommunityToolkit.Mvvm
ObservableObject
        ↓
[ObservableProperty]
        ↓
[NotifyCanExecuteChangedFor]
        ↓
[RelayCommand]
```

を比較し、

**CommunityToolkit.Mvvmが何を省略してくれているのか説明できるようにする。**

---

# 1-5. MVVMの責務

### 学習項目

- View
- ViewModel
- Model
- Service
- Repository
- DTO

### 現在の顧客マスタを題材にする

```text
View
 ↓
ViewModel
 ↓
Service
 ↓
Repository
```

それぞれの責務を整理する。

### 特に考えること

「この処理はどこに置くべきか？」

を自分で判断する。

例：

- 入力値を画面表示用に整形する → ViewModel
- 顧客コードが業務ルール上6桁である → Service / Domain側
- DBへINSERTする → Repository
- 顧客登録という業務処理 → Service
- 画面の入力値 → ViewModel

---

# 1-6. DI基礎

### 学習項目

- DIとは何か
- Interface
- コンストラクタインジェクション
- `MauiProgram`
- `AddTransient`
- `AddSingleton`
- `AddScoped`
- DIコンテナ

### 実践

```text
M_CustomerViewModel
        ↓
IM_CustomerService
        ↓
M_CustomerService
```

という構成を作る。

その後、

```text
M_CustomerService
        ↓
IM_CustomerRepository
        ↓
M_CustomerRepository
```

までDIする。

### 到達目標

単に「DIを使える」だけでなく、

> なぜ直接`new`せず、Interfaceを介してDIするのか

を説明できる。

---

# 1-7. 画面遷移

### 学習項目

- AppShell
- Shell Navigation
- Routing
- `GoToAsync`
- 戻る
- パラメータ渡し
- PageとViewModelの生成
- DIと画面遷移の関係

### 実践

以下の画面を作る。

```text
メニュー
 ├─ 顧客マスタ
 ├─ 旅程マスタ
 └─ 旅行日記
```

---

# 1-8. MAUIのライフサイクル

### 学習項目

- Pageの生成
- `OnAppearing`
- `OnDisappearing`
- 初期化処理
- 画面再表示
- ViewModelのライフサイクル

### 特に確認すること

「画面を開いたときに何をするのか」

「クリアボタンを押したときに何をするのか」

「画面に戻ってきたときに何をするのか」

を区別する。

---

# 1-9. Resources / Styles

### 学習項目

- `App.xaml`
- `ResourceDictionary`
- `StaticResource`
- Style
- Color
- Font

### 実践

アプリ共通の、

- Button
- Label
- Entry

のスタイルを作る。

---

# 1-10. Platforms

### 学習項目

- Android
- iOS
- Windows
- `Platforms`フォルダ
- プラットフォーム固有API
- `#if ANDROID`
- DIによる実装切り替え

### 到達目標

「MAUIだから全部同じコード」ではなく、

> 共通コードとプラットフォーム固有コードをどのように分けるか

を理解する。

---

# 1-11. Feature-Based構成

ここまで学んだ内容を、現在の旅行管理アプリの構成に整理する。

```text
AppTravel
├─ Features
│  ├─ M_Customer
│  │  ├─ Views
│  │  ├─ ViewModels
│  │  ├─ Models
│  │  ├─ Services
│  │  └─ Repositories
│  │
│  └─ M_Trip
│
├─ MVVM
├─ AppCommon
├─ Resources
└─ Platforms
```

### 学習項目

- Feature-Based構成
- 共通部品
- ViewModelBase
- Commands
- フォルダ分割ルール
- READMEによる設計ルールの文書化

---

# 第1段階の完成条件

以下を自分で説明・実装できれば、第1段階を完了とする。

- [ ] MAUIプロジェクトの各ファイル・フォルダの役割を説明できる
- [ ] XAMLで画面を作れる
- [ ] Bindingを説明できる
- [ ] `INotifyPropertyChanged`の仕組みを説明できる
- [ ] Commandの仕組みを説明できる
- [ ] `CanExecute`の意味を説明できる
- [ ] CommunityToolkit.Mvvmを利用できる
- [ ] 自作実装との違いを説明できる
- [ ] View / ViewModelの責務を説明できる
- [ ] Serviceの責務を説明できる
- [ ] Repositoryの責務を説明できる
- [ ] DTOの役割を説明できる
- [ ] DIの仕組みを説明できる
- [ ] `MauiProgram`でDI登録できる
- [ ] Shellによる画面遷移ができる
- [ ] Pageのライフサイクルを理解する
- [ ] Resources / Styleを利用できる
- [ ] Platformsの役割を説明できる
- [ ] Feature-Based構成の意図を説明できる

### 第1段階では「DB」は必須にしない

顧客登録処理は、

```text
入力
 ↓
ViewModel
 ↓
Service
 ↓
（模擬処理）
 ↓
結果を画面表示
```

で構わない。

DBアクセスは、第1段階の理解を確認した後に進む。

---

# 第2段階：SQLiteによるオフラインデータ保存

## 目的

MAUIアプリ単体でデータを永続化する。

```text
MAUI
 ↓
Service
 ↓
Repository
 ↓
SQLite
```

### 学習項目

- SQLite
- 非同期DBアクセス
- CRUD
- Repository
- トランザクション
- DB初期化
- テーブル設計
- Migration / Version管理

### 実践

顧客マスタについて、

- 登録
- 取得
- 更新
- 削除
- 一覧表示

を実装する。

---

# 第3段階：ASP.NET Core Web API

## 目的

MAUIとDBを分離する。

```text
MAUI
 ↓ HTTPS
ASP.NET Core Web API
 ↓
Service
 ↓
Repository
 ↓
MariaDB
```

### 学習項目

- ASP.NET Core Web API
- Controller
- HTTP
- GET / POST / PUT / DELETE
- JSON
- DTO
- Status Code
- APIエラー処理
- Dependency Injection

---

# 第4段階：MariaDB + Web API

## 目的

実際のサーバー側DBアクセスを実装する。

```text
MAUI
 ↓
Web API
 ↓
Service
 ↓
Repository
 ↓
MariaDB
```

### 学習項目

- MariaDB
- 接続文字列
- `IConfiguration`
- `appsettings.json`
- DB接続
- SQL
- Parameter
- CRUD
- トランザクション
- 接続管理

---

# 第5段階：オンライン / オフライン対応

ここで、当初考えていたアプリ構成に進む。

```text
                  ┌─ SQLite
                  │   （オフライン）
MAUI ── Service ──┤
                  │
                  └─ Web API
                       ↓
                    MariaDB
                    （オンライン）
```

## 学習すること

- オンライン判定
- オフライン時の処理
- SQLiteへの保存
- オンライン復帰時の同期
- 同期競合
- データの一意性
- 同期失敗時の再送
- API通信エラー

### DIの実践

例えば、

```text
ICustomerRepository
       ↑
       ├─ SQLiteCustomerRepository
       │
       └─ ApiCustomerRepository
```

のような構成を検討する。

ここで初めて、

> 「DIを使って実装を切り替える」

というメリットを本格的に体験する。

---

# 第6段階：旅行管理アプリの機能拡張

以下を段階的に実装する。

## 顧客

- 顧客マスタ
- 顧客検索
- 顧客編集

## 旅程

- 旅程登録
- 日程管理
- 行程管理

## 交通

- 鉄道
- 特急券
- 航空券

## 宿泊

- 宿泊施設
- チェックイン / チェックアウト
- 予約情報

## 観光

- 観光スポット
- 事前調査
- 訪問予定

## 旅行日記

- 日記登録
- 写真
- 訪問記録

---

# 第7段階：アーキテクチャの発展

ここから、当初の「アーキテクトを目指す」という目的に近づける。

### 学習項目

- SOLID
- Clean Architecture
- Domain Model
- Repository Pattern
- Unit of Work
- CQRS
- Design Patterns
- Dependency Inversion
- テスト容易性
- Mock
- Unit Test
- Integration Test
- API設計
- 認証 / 認可
- ロギング
- エラーハンドリング

---

# 第8段階：マルチプラットフォーム実践

### Android

- 実機
- Emulator
- Android固有機能

### iOS

- 実機
- Simulator
- iOS固有機能
- Apple固有の制約

### Windows

- Windows固有機能

### 最終目標

```text
                ┌─ Android
                │
.NET MAUI ──────┼─ iOS
                │
                └─ Windows
                     │
                     ↓
                 Web API
                     │
                     ↓
                  MariaDB
```

---

# 現在地

現在は、

**第1段階の「1-6 DI基礎」から「1-7以降」へ進んでいる途中。**

特に、

- 自作 `INotifyPropertyChanged`
- 自作 `RelayCommand`
- `CanExecute`
- CommunityToolkit.Mvvm
- `[ObservableProperty]`
- `[RelayCommand]`
- `[NotifyCanExecuteChangedFor]`
- ViewModel → Service → Repository
- DTO
- DI

について実際にコードを書いて経験している。

一方で、まだ第1段階として、

- MAUIのライフサイクル
- Shell / Routing
- Resources / Styles
- Platforms
- Bindingの理解を体系化
- MAUIにおけるDIの理解を整理
- Feature-Based構成の整理

を重点的に学ぶ。

**DB / Web API / MariaDBは一旦保留し、第1段階のMAUI基礎を一通り完成させてから第2段階以降へ進む。**

---

# 学習上の重要なルール

> 「動くこと」だけをゴールにしない。

各機能について、

1. どう書けば動くか
2. なぜそれで動くのか
3. どのクラスが責任を持つべきか
4. 別の実装に差し替えられるか
5. Android / iOSで何が変わるか

を考える。

特にアーキテクチャについては、

> **「この場所に書くのが正しい」ではなく、「なぜこの場所に置くのか」を説明できること**

を目標とする。

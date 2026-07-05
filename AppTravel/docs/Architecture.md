# アーキテクチャ

## 採用している設計

- Feature-Based
- MVVM
- DI

## レイヤー

Features
    業務機能

Infrastructure
    外部との接続

MVVM
    MVVMの基盤

## 依存方向

View
    ↓
ViewModel
    ↓
Service
    ↓
Repository
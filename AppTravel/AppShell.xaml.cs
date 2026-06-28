namespace AppTravel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

        }

        /// <summary>
        /// 各画面のルート登録を呼び出す
        /// </summary>
        public void RegisterRoutes()
        {
            // 顧客登録画面
            RegisterRoutesM_Customer();
            // コース登録画面
            RegisterRoutesM_Course();
        }
    }
}

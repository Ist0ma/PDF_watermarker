namespace PDF_watermarker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show("Thread exception: " + args.Exception.Message + "\n" + args.Exception.StackTrace);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = args.ExceptionObject as Exception;
                MessageBox.Show("Unhandled exception: " + ex?.Message + "\n" + ex?.StackTrace);
            };

            Application.Run(new Form1());
        }
    }
}
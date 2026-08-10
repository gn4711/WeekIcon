using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace WeekIconApp
{
    static class Program
    {
        private static int _currentWeekNumber;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _currentWeekNumber = GetWeekNumber();

            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Text = $"Week {_currentWeekNumber}";
            trayIcon.Icon = GetWeekIcon(_currentWeekNumber);
            trayIcon.Visible = true;

            trayIcon.DoubleClick += (sender, args) =>
            {
                trayIcon.Visible = false;
                Application.Exit();
            };

            // Timer to check for week change (check every hour)
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 60 * 60 * 1000; // 1 hour
            timer.Tick += (sender, args) =>
            {
                int newWeekNumber = GetWeekNumber();
                if (newWeekNumber != _currentWeekNumber)
                {
                    trayIcon.Visible = false;
                    RestartApplication();
                }
            };
            timer.Start();

            Application.Run();
        }

        static int GetWeekNumber()
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday
            );
        }

        static void RestartApplication()
        {
            var exePath = Environment.ProcessPath;
            if (exePath != null)
            {
                Process.Start(exePath);
            }
            Application.Exit();
        }

        static Icon GetWeekIcon(int weekNumber)
        {
            byte[] iconBytes = weekNumber switch
            {
                1 => WeekIcon.Properties.Resources.w1,
                2 => WeekIcon.Properties.Resources.w2,
                3 => WeekIcon.Properties.Resources.w3,
                4 => WeekIcon.Properties.Resources.w4,
                5 => WeekIcon.Properties.Resources.w5,
                6 => WeekIcon.Properties.Resources.w6,
                7 => WeekIcon.Properties.Resources.w7,
                8 => WeekIcon.Properties.Resources.w8,
                9 => WeekIcon.Properties.Resources.w9,
                10 => WeekIcon.Properties.Resources.w10,
                11 => WeekIcon.Properties.Resources.w11,
                12 => WeekIcon.Properties.Resources.w12,
                13 => WeekIcon.Properties.Resources.w13,
                14 => WeekIcon.Properties.Resources.w14,
                15 => WeekIcon.Properties.Resources.w15,
                16 => WeekIcon.Properties.Resources.w16,
                17 => WeekIcon.Properties.Resources.w17,
                18 => WeekIcon.Properties.Resources.w18,
                19 => WeekIcon.Properties.Resources.w19,
                20 => WeekIcon.Properties.Resources.w20,
                21 => WeekIcon.Properties.Resources.w21,
                22 => WeekIcon.Properties.Resources.w22,
                23 => WeekIcon.Properties.Resources.w23,
                24 => WeekIcon.Properties.Resources.w24,
                25 => WeekIcon.Properties.Resources.w25,
                26 => WeekIcon.Properties.Resources.w26,
                27 => WeekIcon.Properties.Resources.w27,
                28 => WeekIcon.Properties.Resources.w28,
                29 => WeekIcon.Properties.Resources.w29,
                30 => WeekIcon.Properties.Resources.w30,
                31 => WeekIcon.Properties.Resources.w31,
                32 => WeekIcon.Properties.Resources.w32,
                33 => WeekIcon.Properties.Resources.w33,
                34 => WeekIcon.Properties.Resources.w34,
                35 => WeekIcon.Properties.Resources.w35,
                36 => WeekIcon.Properties.Resources.w36,
                37 => WeekIcon.Properties.Resources.w37,
                38 => WeekIcon.Properties.Resources.w38,
                39 => WeekIcon.Properties.Resources.w39,
                40 => WeekIcon.Properties.Resources.w40,
                41 => WeekIcon.Properties.Resources.w41,
                42 => WeekIcon.Properties.Resources.w42,
                43 => WeekIcon.Properties.Resources.w43,
                44 => WeekIcon.Properties.Resources.w44,
                45 => WeekIcon.Properties.Resources.w45,
                46 => WeekIcon.Properties.Resources.w46,
                47 => WeekIcon.Properties.Resources.w47,
                48 => WeekIcon.Properties.Resources.w48,
                49 => WeekIcon.Properties.Resources.w49,
                50 => WeekIcon.Properties.Resources.w50,
                51 => WeekIcon.Properties.Resources.w51,
                52 => WeekIcon.Properties.Resources.w52,
                53 => WeekIcon.Properties.Resources.w53,
                _ => WeekIcon.Properties.Resources.w52
            };

            if (iconBytes != null)
            {
                using var ms = new MemoryStream(iconBytes);
                return new Icon(ms);
            }

            return SystemIcons.Application;
        }

    }
}


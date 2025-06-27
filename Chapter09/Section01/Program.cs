using System.Collections.Concurrent;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var now = DateTime.Now;

            //Console.WriteLine($"Today:{today}");
            //Console.WriteLine($"Now:{now}");

            //①自分の生年月日は何曜日かをプログラミングを書いて調べる
            Console.WriteLine("---------① 自分の生年月日は何曜日か---------");
            Console.WriteLine();

            //日付入力
            //西暦
            Console.Write("西暦：");
            var year = Console.ReadLine();
            int year1 = int.Parse(year);
            //月
            Console.Write("月：");
            var month = Console.ReadLine();
            int month1 = int.Parse(month);

            //日
            Console.Write("日：");
            var day = Console.ReadLine();
            int day1 = int.Parse(day);

            var today = new DateTime(year1, month1, day1);//日付
            DayOfWeek dayOfWeek = today.DayOfWeek;
            string japaneseDay = today.ToString("dddd", new System.Globalization.CultureInfo("ja-JP"));
            Console.WriteLine($"{today}は{japaneseDay}です。");

            //②うるう年の判定プログラムを作成する
            Console.WriteLine();
            Console.WriteLine("-----② うるう年の判定-----");
            Console.WriteLine();
            var isLeapYear = DateTime.IsLeapYear(year1);
            if (isLeapYear) {
                Console.WriteLine($"{year1}年はうるう年です。");
            } else {
                Console.WriteLine($"{year1}年はうるう年ではないです。");
            }
            Console.WriteLine();
            Console.WriteLine("-----------② 和暦変換----------");
            Console.WriteLine();

            if (now.Year >= today.Year && today.Year >= 2018) {
                Console.WriteLine($"令和{today.Year}年です。");
            } else if (2018 > today.Year && today.Year >= 1989) {
                Console.WriteLine($"平成{today.Year}年です。");
            } else if (1989 > today.Year && today.Year >= 1926) {
                Console.WriteLine($"昭和{today.Year}年です。");
            } else {
                Console.WriteLine("クソ老人は墓に入ってろ！！");
            }

            Console.WriteLine();
            Console.WriteLine("-----------③ 生まれてから何日目か----------");
            Console.WriteLine();

            TimeSpan diff = now.Date - today.Date;
            Console.WriteLine($"{diff.Days + 1}日目です。");

            Console.WriteLine();
            Console.WriteLine("-----------④ 年齢----------");
            Console.WriteLine();

            Console.WriteLine($"あなたは{now.Year - today.Year}歳です。");

            Console.WriteLine();
            Console.WriteLine("-----------⑤ １月１日から何日目----------");
            Console.WriteLine();

            var firstday = new DateTime(now.Year,1,1);
            TimeSpan firstDay = now.Date - firstday.Date ;
            Console.WriteLine($"今年の１月１日から{firstDay.Days + 1}日目です。");
        }
    }
}

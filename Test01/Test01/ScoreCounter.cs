namespace Test01 {
    public class ScoreCounter {
        private readonly IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 
        public static IEnumerable<Student> ReadScore(string filePath) {
            var scores = new List<Student>();
            var points = File.ReadAllLines(filePath);
            foreach (var line in points) {
                string[] items = line.Split(',');
                //Saleオブジェクトを生成
                var score = new Student() {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                scores.Add(score);
            }
            return scores;

        }

        //メソッドの概要： 
        public Dictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var i in _score) {
                if (dict.ContainsKey(i.Subject)) {
                    dict[i.Subject] += i.Score;
                } else {
                    dict[i.Subject] = i.Score;
                }
            }
            return dict;
        }
    }
}

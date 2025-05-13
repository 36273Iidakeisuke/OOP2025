namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2.1.3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };





            printSongs(songs);
        }

        //2.1.4
        //foreach(var song in songs){
        //var minutes = Song.Length / 60;
        //var seconds = Song.Length % 60;
        //Console.WriteLine
        //           ($"title:{song.Title,-30}, artist:{song.ArtistName,-20},{minutes}:{seconds:00}");
        //   }

        
        
        //TimeSpanの構成
        private static void printSongs(Song[] songs) {
            foreach (var song in songs) {
                var timeSpan = new TimeSpan(0, 0, song.Length);
                Console.WriteLine
                    ($"title:{song.Title,-30}, artist:{song.ArtistName,-20}, time:{timeSpan.ToString(@"mm\:ss")}");
            }
        }
    }
}

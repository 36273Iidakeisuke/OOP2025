using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //2.1.1
    public class Song {
        public string Title { get; set; } = String.Empty;
        string ArtistName { get; set; } = String.Empty;
        int Length { get; set; }
        //2.1.2
        public Song(string title,string artistName,int length) {
            Title = title;
            ArtistName = artistName;
            Length = length;
        } 

    }
}

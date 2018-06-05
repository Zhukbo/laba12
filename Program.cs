using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               /* Song first = new Song("Thunder", "LoLo", 50, "ZXit");
                Song second = new Song("Abc", "bomb", 179, "fgfg");
                Song fifth = new Song("Ride", "Twenty One Pilots", 201, "POlka");*/
                Song third = new Song();
                Console.WriteLine(third.Album);



                MusicList listofmusic = new MusicList();
                /*listofmusic.AddSong(first);
                listofmusic.AddSong(second);
                listofmusic.AddSong(third);
                listofmusic.AddSong(fifth);*/

                //Console.WriteLine(DateTime.Now.Day + " ");


                //listofmusic.SortingDuration();
                listofmusic.SortingAlbum();


                //Console.WriteLine(listofmusic.AverageDuration());


                int lengthCollect = listofmusic.TakeLengthCollection;

                /*for(int i = 0; i < lengthCollect; i++)
                {
                    Console.WriteLine(listofmusic[i].Album);
                }*/
                for (int i = 0; i < lengthCollect; i++)
                {
                    Console.WriteLine(listofmusic[i].Album + " тривалість " + listofmusic[i].Duration);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }
    }
    class Song
    {
        private string name;
        private string performer;
        private int duration;
        private string album;

        /*public Song(string name, string performer, int duration, string album) : this()
        {
            this.name = name;
            this.performer = performer;
            this.duration = duration;
            this.album = album;
        }
        public Song()
        {
            this.name = "kkk";
            this.performer = "kirkorov";
            this.duration = 40;
            this.album = "Vesna";

        }*/
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }
        public string Performer
        {
            get
            { return performer; }
            set
            { performer = value; }
        }
        public int Duration
        {
            get
            { return duration; }
            set
            {
                if (value > 0)
                    duration = value;
                else
                    duration = 30;
            }
        }
        public string Album
        {
            get
            { return album; }
            set
            { album = value; }
        }
        public override bool Equals(object obj)
        {
            Song track = obj as Song;

            if (track == null)
                return false;
            return (this.name == track.Name && this.performer == track.Performer && this.Album == track.Album);
        }

        public static bool Equals(Song a, Song b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }

        public static bool operator ==(Song obj1, Song obj2)
        {
            return Equals(obj1, obj2);
        }

        public static bool operator !=(Song obj1, Song obj2)
        {
            return !Equals(obj1, obj2);
        }

        public override int GetHashCode()
        {
            return (name + performer + album).GetHashCode();
        }

        public override string ToString()
        {
            return "name " + this.Name + " performer " + this.Performer + " duration " + this.Duration + " album " + this.Album;
        }
    }

    class MusicList
    {
        private List<Song> music;

        public MusicList()
        {
            music = new List<Song> { };
        }

        // цей метод додає пісню
        public void AddSong(Song s)
        {
            if (music.Contains(s))
                throw new FormatException("Така пiсня уже iснує у списку");
            else
                music.Add(s);
        }

        // цей метод видаляє пісню
        public void DeleteSong(string mus)
        {
            for (int i = 0; i < music.Count; i++)
            {
                if (music[i].Name == mus)
                {
                    music.Remove(music[i]);
                }
            }

        }
        // цей метод видаляє пісню через тривалість
        public void DeleteSongViaDuration(int dur)
        {
            for (int i = 0; i < music.Count; i++)
            {
                if (music[i].Duration >= dur)
                {
                    music.Remove(music[i]);
                }
            }
        }
        // цей метод обчислює загальну тривалість
        public int TotalDuration()
        {
            int k = 0;
            foreach (Song i in music)
            {
                k += i.Duration;
            }
            return k;
        }
        // цей метод обчислює середнє значення тривалості
        public int AverageDuration()
        {
            if (music.Count == 0)
                return 0;
            else
                return TotalDuration() / music.Count;
        }

        //цей метод сортує пісні за тривалістю
        public void SortingDuration()

        {
            Song temp;
            for (int i = 0; i < music.Count - 1; i++)
            {
                for (int k = i + 1; k < music.Count; k++)
                {
                    if (music[i].Duration > music[k].Duration)
                    {
                        temp = music[i];
                        music[i] = music[k];
                        music[k] = temp;

                    }
                }
            }
        }
        //метод сортує пісні за альбомом
        public void SortingAlbum()
        {
            Song temp;
            for (int i = 0; i < music.Count - 1; i++)
            {
                for (int k = i + 1; k < music.Count; k++)
                {
                    if (music[i].Album.CompareTo(music[i + 1].Album) > 0)
                    {
                        temp = music[i];
                        music[i] = music[k];
                        music[k] = temp;
                    }
                }
            }
        }

        // повертає кількість пісень
        public int TakeLengthCollection
        {
            get
            { return music.Count; }
        }

        // індексатор повертає індекс пісні
        public Song this[int index]
        {
            get
            {
                if (index < 0 && index > music.Count && music[index] == null)
                    throw new IndexOutOfRangeException("Щось пішло не так");
                return music[index];

            }
        }
    }

    class MusicException : Exception
    {
        public MusicException(string message) : base(message) { }
    }
}

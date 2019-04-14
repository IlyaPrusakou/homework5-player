using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Audioplayer
{
    class Program
    {

        //B5-Player7/10. OutRefParameters.
        public static int TotalDur;
        public static string Prop = "s";
        
        public static int CreateSong(Song[] s, ref int xshort, ref int ylong, out string _shortname, out string _longname)
        {
            Random rnd = new Random();
            _shortname = Prop;
            _longname = Prop;
            for (int i = 0; i < s.Length; i++)
            {
                
                s[i] = new Song();
                s[i].title = "songN" + i;
                WriteLine(s[i].title);
                s[i].duration = rnd.Next(500);
                WriteLine(s[i].duration);
                TotalDur = TotalDur + s[i].duration;
                WriteLine($"iteration {i} " + TotalDur);
                if (s[i].duration < xshort)
                {
                    xshort = s[i].duration;
                    _shortname = s[i].title;
                }
                if (s[i].duration > ylong)
                {
                    ylong = s[i].duration;
                    _longname = s[i].title;
                }
            }
            WriteLine(xshort + " " + _shortname);
            WriteLine(ylong + " " + _longname);
            return TotalDur;
        }
        // helper
        public static string GeneratorRandomStrings()
            
        {
            Random rndgen = new Random();
            string randomstring = "s";
            for (int i = 1; i < 5; i++)
            {
                randomstring = randomstring + Convert.ToString((char)rndgen.Next(100));
            }
            WriteLine("Result random generate" + randomstring);
            return randomstring;
        }
        //B5-Player9/10. MethodOverloading and B5-Player6/10. MethodParameters. 
        public static Song InitSong()
        {
            Random rndDefault = new Random();
            Song defaultsong = new Song();
            defaultsong.title = GeneratorRandomStrings();
            defaultsong.duration = rndDefault.Next(500);
            defaultsong.album = new Album ();
            defaultsong.artist = new Artist();
            defaultsong.lyrics = GeneratorRandomStrings();
            defaultsong.songPath = GeneratorRandomStrings();
            defaultsong.playlists = new Playlist[2];
            return defaultsong;
        }

        public static Song InitSong(string _name)
        {
            var defsong = InitSong();
            defsong.title = _name;
            return defsong;
        }

        public static Song InitSong(string _title, int dur, Album _album, Artist _artist, string _lyrics, Playlist[] _playlist)
        {
            Song initsong = new Song();
            initsong.title = _title;
            initsong.duration = dur;
            initsong.album = _album;
            initsong.artist = _artist;
            initsong.lyrics = _lyrics;
            initsong.songPath = GeneratorRandomStrings();
            initsong.playlists = _playlist;
            return initsong;
        }
        //B5-Player10/10. DefaultAndNamedParamters.
        public static Artist AddArtist(string _name = "unknown artist")
        {
            Artist artist = new Artist();
            artist.name = _name;
            return artist;
        }

        public static Album AddAlbum(string _name = "unknown album", int _year = 0)
        {
            Album album = new Album();
            album.name = _name;
            album.year = _year;
            return album;
        }

        static void Main(string[] args)
        {
            int shortSong = 100000;
            int longSong = 0;
            string shortname;
            string longname;

            //B5 - Player10 / 10.DefaultAndNamedParamters.
            Artist tryArtist = AddArtist();
            WriteLine(tryArtist.name);
            Artist tryArtist2 = AddArtist("DDT");
            WriteLine(tryArtist2.name);

            Album tryAlbum = AddAlbum();
            WriteLine(tryAlbum.name + "   " + tryAlbum.year);
            Album tryAlbum2 = AddAlbum("Zelenii les",  1988);
            WriteLine(tryAlbum2.name + "   " + tryAlbum2.year);

            Album tryAlbum3 = AddAlbum(_year: 1999, _name: "Eminem");
            WriteLine(tryAlbum3.name + "   " + tryAlbum3.year);

            // create playlist to try relation ∞ objects to ∞ objects (B5-Player2/10. Fields.)
            Playlist mainPlaylist = new Playlist();
            Playlist secondPlayList = new Playlist();

            // try overload constructors (B5-Player5/10. Constructors.)
            Artist artist1 = new Artist();
            Artist artist2 = new Artist("Vasya");
            WriteLine(artist2.name);
            // try to calculate total duration of song in array (B5-Player7/10. OutRefParameters.)
            Song[] songs = new Song[5];
            CreateSong(songs, ref shortSong, ref longSong, out shortname, out longname);
            WriteLine("Result" + shortname);
            
            // B5-Player9/10. MethodOverloading and B5-Player6/10. MethodParameters.
            Song testsong = InitSong();
            WriteLine( testsong.title + "   " + testsong.lyrics + "    " + testsong.duration + "   " + 
                testsong.songPath + "   " + testsong.artist + "   " + testsong.album);
            Song testNamedSong = InitSong("lalal");
            WriteLine(testNamedSong.title + "   " + testNamedSong.songPath);

            Song testInitSong = InitSong("pachka sigaret", 500, new Album(), new Artist { name = "Sector gaza" }, "lalalala", new Playlist [5]);
            WriteLine(testInitSong.title + "  " + testInitSong.artist.name);



            // B5-Player2/10. Fields.
            Song song1 = new Song();

            song1.duration = 300;
            song1.title = "Cvet nastroenia sinii";
            song1.songGenre = "Metal";
            song1.lyrics = "lalala";
            song1.artist = new Artist{name = "Kirkorov"};
            song1.playlists[0] = mainPlaylist;
            song1.playlists[1] = secondPlayList;

            // B5-Player2/10. Fields.
            Song song2 = new Song();
            song2.duration = 300;
            song2.title = "Anaconda";
            song2.songGenre = "Pop";
            song2.lyrics = "lalala";
            song2.artist = new Artist
            {
                name = "Minaj",
                band = new Band
                {
                    bandYear = 1988,
                    isExist = true
                }
            };
            song2.album = new Album
            {
                name = "MinajAlbum",
                path = "pathAlbum",
                year = 1988
            };
            song2.playlists[0] = mainPlaylist;
            song2.playlists[1] = secondPlayList;
            song2.artist.band.bandTitle = "MinajBand";

            // try relations between playlists and songs, and set some fields of playlist (B5-Player2/10. Fields.)
            mainPlaylist.title = "Main";
            mainPlaylist.path = "Path1";
            mainPlaylist.Songs[0] = song1;
            mainPlaylist.Songs[1] = song2;

            mainPlaylist.title = "Second";
            mainPlaylist.path = "Path2";
            secondPlayList.Songs[0] = song1;
            secondPlayList.Songs[1] = song2;

            // output some fields (B5-Player2/10. Fields.)
            WriteLine(mainPlaylist.title);
            WriteLine(mainPlaylist.Songs[1].title);
            WriteLine(song1.title);
            WriteLine(song1.playlists[0].title);
            WriteLine(song2.lyrics);
            WriteLine(song2.playlists[1].title);
            WriteLine(song2.album.name);
            WriteLine(song2.artist.band.bandTitle);
            // create array of songs (B5-Player8/10. ParamsParameters)
            Song[] arrayList = new Song[5];
                for (int i = 0; i < arrayList.Length; i++)
            {
                arrayList[i] = new Song();
                arrayList[i].title = "paramsong" + i;
            }

            //B5 - Player1 / 10.Classes.
            Player player = new Player();

            //B5 - Player8 / 10.ParamsParameters
            player.ParametrSong();
            player.ParametrSong(new Song { title = "1aaa" });
            player.ParametrSong(new Song { title = "1" }, new Song { title = "2" });
            player.ParametrSong(arrayList);

            // try to set read only property (B5-Player4/10. Properties.)
            //player.Playing = false; it is read only

            player.songs = new[] { song1, song2 };

            // try to increase the max boarder of volume value (B5-Player4/10. Properties.)
            player.Volume = 5000;
            WriteLine("output must be 100 -- " + player.Volume);

            // try to invoke some methods in code (B5-Player3/10. Method.) 
            player.VolumeChange(25, "+");
            player.VolumeChange(5, "-");
            player.VolumeDown();
            player.VolumeUp();
            player.Lock();
            player.UnLock();
            player.Start();
            player.Play();

            WriteLine("Now we try to use your keyboard");

            // try to invoke methods by switch controller (B5-Player3/10. Method. )
            while (true)
            {
                switch (ReadLine())
                {
                    case "a":
                        {
                            player.VolumeUp();
                            break;
                        }
                    case "s":
                        {
                            player.VolumeDown();
                            break;
                        }
                    case "d":
                        {
                            player.Play();
                            break;
                        }
                    case "q":
                        {
                            player.Lock();
                            break;
                        }
                    case "w":
                        {
                            player.UnLock();
                            break;
                        }
                    case "e":
                        {
                            player.Start();
                            break;
                        }
                    case "r":
                        {
                            player.Stop();
                            break;
                        }

                }
            }



            ReadLine();
        }
    }
}
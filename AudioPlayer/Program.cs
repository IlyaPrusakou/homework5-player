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

        static void Main(string[] args)
        {
            // create playlist to try relation ∞ objects to ∞ objects
            Playlist mainPlaylist = new Playlist();
            Playlist secondPlayList = new Playlist();

            // set fields with initializator for song1
            Song song1 = new Song
            {
                duration = 300,
                title = "Cvet nastroenia sinii",
                songGenre = "Metal",
                lyrics = "lalala",
                artist = new Artist
                {
                    name = "Kirkorov"
                },

            };

            // set fields with . operator for song1
            song1.playlists[0] = mainPlaylist;
            song1.playlists[1] = secondPlayList;

            // set fields with initializator for song2
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

            // set fields with . operator for song2
            song2.album = new Album
            {
                name = "MinajAlbum",
                path = "pathAlbum",
                year = 1988
            };
            song2.playlists[0] = mainPlaylist;
            song2.playlists[1] = secondPlayList;
            song2.artist.band.bandTitle = "MinajBand";

            // try relations between playlists and songs, and set some fields of playlist
            mainPlaylist.title = "Main";
            mainPlaylist.path = "Path1";
            mainPlaylist.Songs[0] = song1;
            mainPlaylist.Songs[1] = song2;

            mainPlaylist.title = "Second";
            mainPlaylist.path = "Path2";
            secondPlayList.Songs[0] = song1;
            secondPlayList.Songs[1] = song2;

            // output some fields
            WriteLine(mainPlaylist.title);
            WriteLine(mainPlaylist.Songs[1].title);
            WriteLine(song1.title);
            WriteLine(song1.playlists[0].title);
            WriteLine(song2.lyrics);
            WriteLine(song2.playlists[1].title);
            WriteLine(song2.album.name);
            WriteLine(song2.artist.band.bandTitle);

            Player player = new Player();

            // try to set read only property
            //player.Playing = false; it is read only

            player.songs = new[] { song1, song2 };

            // try to increase the max boarder of volume value
            player.Volume = 5000;
            WriteLine("output must be 100 -- " + player.Volume);

            // try to invoke some methods in code
            player.VolumeChange(25, "+");
            player.VolumeChange(5, "-");
            player.VolumeDown();
            player.VolumeUp();
            player.Lock();
            player.UnLock();
            player.Start();
            player.Play();

            WriteLine("Now we try to use your keyboard");

            // try to invoke methods by switch controller
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
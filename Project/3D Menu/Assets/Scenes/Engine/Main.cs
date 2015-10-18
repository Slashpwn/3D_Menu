using UnityEngine;
using System.Collections;
using System.IO;

public class Main : MonoBehaviour {
	ArrayList songpool;
	Playlist currentPlaylist;
	PlaylistItem currentSong;
	bool playlistPlay = true;
	bool shuffle = false;
	int count = 0;
	ArrayList allPlaylists;
	AudioSource player;
	AudioClip clp;

	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource>();
		loadAllPlaylists ();
		loadSongpool ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp("a")){
			prev ();
			Debug.Log ("Previous");
		}
		if(Input.GetKeyUp("s")){
			play ();
			Debug.Log ("Play");
		}
		if(Input.GetKeyUp("d")){
			pause ();
			Debug.Log ("Pause");
		}
		if(Input.GetKeyUp("f")){
		next ();
			Debug.Log ("Next");
		}
		if(Input.GetKeyUp("x")){
			shuffleTogle ();
			Debug.Log ("Shuffle: "+shuffle);
		}
		if(Input.GetKeyUp("c")){
			searchForFiles ("C:");
		}
	}

	void play(){
		player.Play();
	}

	void pause(){
		player.Pause ();

	}

	void next(){
		if(playlistPlay && count<currentPlaylist.length && !shuffle){

			count++;
			currentSong = currentPlaylist.PL[count];
		}

	}

	void prev(){


	}

	void shuffleTogle(){
		shuffle = !shuffle;

	}

	void getNext(){


	}

	void loadAllPlaylists(){


	}

	void savePlaylist(Playlist pl){

	}

	void newPlaylist(string newName){
		Playlist newPl = new Playlist (newName);
		allPlaylists.Add (newPl);

	}

	void deletePlaylist(){


	}

	void searchForFiles(string baseDirectory){
		DirectoryInfo dir = new DirectoryInfo(baseDirectory);
		DirectoryInfo[] directories = dir.GetDirectories();
		foreach (DirectoryInfo d in directories) {
			searchForFiles (d.FullName);		
		
		}
		FileInfo[] info = dir.GetFiles("*.mp3");
		foreach (FileInfo f in info) {
			//PlaylistItem tempPI = ;
			//songpool.Add(tempPI);
			Debug.Log(f.Name);
		}

	}

	void loadSongpool(){


	}

}

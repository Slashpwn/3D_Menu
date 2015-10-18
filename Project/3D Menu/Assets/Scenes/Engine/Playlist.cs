using UnityEngine;
using System.Collections;

public class Playlist : MonoBehaviour {
	PlaylistItem[] PLI;
	string name;
	int length;
	int lastPlay;

	public Playlist(string name){
		this.name = name;
	
	}

	void add(){


	}

	void remove(){


	}

	void getNoOfItems(){


	}

	PlaylistItem getNext(int count){

		return PLI [count + 1];
	}
}


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;

//I made this using Tea lover's scripting tutorials and SharpDevelop, sorry for my English (I guess idk)

namespace CreateFadeToCursor
{
	
	public class EntryPoint
	{
		public void FromVegas(Vegas myVegas)//the main program, this gets executed in Vegas
		{
			try{//tries to execute the script
			TrackEvent[] selectedev = GetSelectedEvents(myVegas.Project);//gets the currently selected events
			Timecode curspos = myVegas.Transport.CursorPosition;//gets the cursor's current position
			foreach (TrackEvent myEvent in selectedev) {//for every selected event
				myEvent.FadeIn.Length = curspos-myEvent.Start;//sets the lenght of the event's fade to the difference of the 2 timecode
			}
			}
			catch (Exception ex){//if there is an error
				MessageBox.Show(ex.Message);//the script throws up an error message
			}
			
		}
		
		
		TrackEvent[] GetSelectedEvents(Project project){//this method puts the currently selected events to an array
			List<TrackEvent> selected = new List<TrackEvent>();//creates a TrackEvent List which will contain the currently selected events
			foreach (Track track in project.Tracks) {//for each track in the project
				foreach (TrackEvent Tevent in track.Events) {//for each event on the track
					if (Tevent.Selected){//if the event is selected it gets added to the list
						selected.Add(Tevent);
					}
				}
			}
			return selected.ToArray();//converts the completed list to an array
		}
	}
}
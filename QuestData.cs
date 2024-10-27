using System.Collections;
using System.Collections.Generic;


public class QuestData
{
    public string questName;
    public int[] npcId;

    public QuestData(string questName, int[] npc)
    {
        this.questName = questName;
        this.npcId = npc;
    } 
}

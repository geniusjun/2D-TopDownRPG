using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        //Talk Data
        //Npc A : 1000, NPC B : 2000
        //Box : 100, Desk : 200
        talkData.Add(1000, new string[] { "안녕?:0" , "이 곳에 처음 왔구나?:1", "한번 둘러보도록 해~:0"});
        talkData.Add(2000, new string[] { "어어~:0" , "이 호수 정말 아름답지 않아?:1",
                                            "이 호수에는 비밀이 숨겨져 있다고 해 바로..:2",
                                            "료이키 텐카이.:3"});

        talkData.Add(100, new string[] { "평범한 나무 상자다."});
        talkData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다."});

        //Quest Talk
        //        Quese Id + Npc Id 신기하다 이런 방법
        talkData.Add(10 + 1000, new string[] { "어서 와...:0",
                                                "이 마을 호수에 놀라운 전설이 있다는데:1",
                                                "오른쪽 호수 쪽에 사토루가 알려줄거야.:2"});

        talkData.Add(11 + 2000, new string[] {"여어...:1",
                                            "이 호수의 전설을 들으러 온거야?:0",
                                             "그럼 일 좀 하나 해주면 알려주겠네..:1",
                                             "내 집 근처에 떨어진 동전 좀 주워줬으면 하네.:1"});

        talkData.Add(20 + 1000, new string[] {"사토루의 동전?:1",
                                            "돈을 흘리고 다니면 못쓰지!:3",
                                             "나중에 사토루에게 한마디 해야겠어!:3"});
        talkData.Add(20 + 2000, new string[] { "찾으면 꼭 좀 가져다 줘:1", });
        talkData.Add(20 + 5000, new string[] { "근처에서 동전을 찾았다.", });

        talkData.Add(21 + 2000, new string[] { "엇, 찾아줘서 고마워.:2", });
                                             

        //Portrait Data
        //0 : Normal, 1 : Speak, 2 : Happy, 3 : Angry
        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사마저 없을 때 (ex. box 사물 등등)
                //기본 대사를 가지고 온다.
                return GetTalk(id - id % 100, talkIndex); // Get First Talk, 재귀로 구현 OMG , 나머지 연산으로 구분하는거 대박,,,
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때.
                //퀘스트 맨 처음 대사를 가지고 온다.
                return GetTalk(id-id % 10, talkIndex); //Get First Quest Talk
            }
        }
        if (talkIndex == talkData[id].Length)
        {
            return null; 
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id +  portraitIndex]; 
    }
}

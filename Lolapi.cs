using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace lolapi{
class Program
{ 
    static void Main()
    {
        
        // Your API key, username, and tagline
        string api_key = "RGAPI-4f16a338-efe0-4932-8160-5478bbedd0aa";
        string username = "softfeathers";
        string tagline = "euw";
        string[] listofplayedcharacters = { "Xayah", "Tristana", "Sivir", "Caitlyn", "Smolder", "MissFortune" };
        
      
    
        

        Dictionary<int, string> summonerspells = new Dictionary<int, string>{
            { 21, "barrier" },
            { 1, "cleanse" },
            {4, "flash"},
            {14, "ignite"},
            {3, "exhaust"},
            {6, "ghost"},
            {7, "heal"},
            {13, "clarity"},
            {11, "smite"},
            {12, "teleport"}
        };

        // Construct URL to retrieve player's PUUID
        string getpuuidurl = $"https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{username}/{tagline}?api_key={api_key}";

        // Make HTTP request to retrieve PUUID
        string puuid;
        try
        {
            string puuidJson;
            using (WebClient client = new WebClient())
            {
                puuidJson = client.DownloadString(getpuuidurl);
            }
            PuuidResponse puuidResponse = JsonSerializer.Deserialize<PuuidResponse>(puuidJson);
            puuid = puuidResponse.puuid;
        }
        catch (WebException ex)
        {
            Console.WriteLine($"Error fetching PUUID: {ex.Message}");
            return;
        }

        // Construct URL to retrieve match IDs
        string getMatchesUrl = $"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuid}/ids?start=0&count=100&api_key={api_key}";

        // Make HTTP request to retrieve match IDs
        string[] matchIds;
        try
        {
            string matchIdsJson;
            using (WebClient client = new WebClient())
            {
                matchIdsJson = client.DownloadString(getMatchesUrl);
            }
            matchIds = JsonSerializer.Deserialize<string[]>(matchIdsJson);
        }
        catch (WebException ex)
        {
            Console.WriteLine($"Error fetching match IDs: {ex.Message}");
            return;
        }

        using StreamWriter writer = new StreamWriter("MatchData.csv");
        string headers = "Match ID, start time, Game Duration,Game Mode, queueid, Game type, Game Version,Participant ID," +
                                     "Champion Name,Kills,Deaths,Assists,Gold Earned," +
                                     "Summoner Spell 1,Summoner Spell 2,First Blood Kill," +
                                     "Damage Dealt to Buildings,Game Ended in Surrender,Largest Multi Kill," +
                                     "Longest Time Spent Living,Total Minions Killed,Total Damage Dealt to Champions," +
                                     "Time CCing Others,Detector Wards Placed,Vision Score,Win";
        writer.WriteLine(headers);
        string[] NewMatchIDsfirsthalf = new string[]{
    "EUW1_6924573866",
    "EUW1_6924552760",
    "EUW1_6924513284",
    "EUW1_6924496048",
    "EUW1_6924440601",
    "EUW1_6924379273",
    "EUW1_6924309311",
    "EUW1_6915874017",
    "EUW1_6915822541",
    "EUW1_6915763003",
    "EUW1_6915658842",
    "EUW1_6915658842",
    "EUW1_6915555665",
    "EUW1_6915507566",
    "EUW1_6915444436",
    "EUW1_6915371417",
    "EUW1_6915330326",
    "EUW1_6914995996",
    "EUW1_6914945804",
    "EUW1_6914870738",
    "EUW1_6913905848",
    "EUW1_6913808352",
    "EUW1_6913792688",
    "EUW1_6913773149",
    "EUW1_6913752670",
    "EUW1_6913739942",
    "EUW1_6913242272",
    "EUW1_6913164089",
    "EUW1_6913099891",
    "EUW1_6913050113",
    "EUW1_6912303911",
    "EUW1_6912247289",
    "EUW1_6912178209",
    "EUW1_6912105220",
    "EUW1_6911834177",
    "EUW1_6911749970",
    "EUW1_6911702210",
    "EUW1_6911647246",
    "EUW1_6911447085",
    "EUW1_6911401591",
    "EUW1_6911344108",
    "EUW1_6911296978",
    "EUW1_6911259722",
    "EUW1_6911218681",
    "EUW1_6911153063",
    "EUW1_6911136149",
    "EUW1_6910927335",
    "EUW1_6910925482",
    "EUW1_6910900543"
};

        string[] NewMatchIDsFromList = new string[]{
"EUW1_6910858517",
"EUW1_6910814201",
"EUW1_6910769158",
"EUW1_6910718623",
"EUW1_6910643398",
"EUW1_6910494414",
"EUW1_6910413273",
"EUW1_6910342838",
"EUW1_6910277531",
"EUW1_6910200042",
"EUW1_6909992692",
"EUW1_6909928155",
"EUW1_6907342702",
"EUW1_6907229228",
"EUW1_6907176207",
"EUW1_6906590425",
"EUW1_6906565520",
"EUW1_6839546936",
"EUW1_6837329540",
"EUW1_6837273575",
"EUW1_6837209643",
"EUW1_6834583248",
"EUW1_6834533909",
"EUW1_6834487822",
"EUW1_6834400733",
"EUW1_6834345902",
"EUW1_6834284382",
"EUW1_6834236951",
"EUW1_6834177114",
"EUW1_6818197263",
"EUW1_6818136777",
"EUW1_6818111208",
"EUW1_6818066066",
"EUW1_6801397987",
"EUW1_6801329820",
"EUW1_6801275133",
"EUW1_6801234078",
"EUW1_6801185964",
"EUW1_6801143897",
"EUW1_6801083218",
"EUW1_6801042968",
"EUW1_6796860557",
"EUW1_6796716950",
"EUW1_6796627852",
"EUW1_6796554276",
"EUW1_6796511823",
"EUW1_6793666445",
"EUW1_6793173967",
"EUW1_6793112176",
"EUW1_6791929016",
"EUW1_6787863934",
"EUW1_6781696183",
"EUW1_6781674616",
"EUW1_6780109544"
};// Process each match

        bool auto = false; //get ids with api
        bool batch1 = true; //use preset array 1

        if (auto)
        {
            getthematches(matchIds);
        }
        else if (batch1)
        {
            getthematches(NewMatchIDsfirsthalf);
        }
        else
        { //auto preset array 2
            getthematches(NewMatchIDsFromList);
        }

        void getthematches(string[] matchsource)
        {
            foreach (string matchId in matchsource)
            {
                // Construct URL to retrieve match data
                string getMatchUrl = $"https://europe.api.riotgames.com/lol/match/v5/matches/{matchId}?api_key={api_key}";

                try
                {
                    // Make HTTP request to retrieve match data
                    string matchJson;
                    using (WebClient client = new WebClient())
                    {
                        matchJson = client.DownloadString(getMatchUrl);
                    }

                    // Deserialize JSON response into Match object
                    Match match = JsonSerializer.Deserialize<Match>(matchJson);
                    

                    if (match.info.gameMode != "ARAM")
                    {
                        // Process participants
                        foreach (Participant participant in match.info.participants)
                        {

                            if (participant.puuid == puuid && listofplayedcharacters.Contains(participant.championName))
                            {

                                Console.WriteLine($"Match ID: {match.metadata.matchId}");
                                Console.WriteLine($"Game Duration: {match.info.gameDuration}");
                                Console.WriteLine($"Game Mode: {match.info.gameMode}");
                                Console.WriteLine($"Game Version: {match.info.gameVersion}");
                                Console.WriteLine($"queueid {match.info.queueId}");
                                
                                Console.WriteLine($"Participant ID: {participant.participantId}");
                                Console.WriteLine($"Champion Name: {participant.championName}");
                                Console.WriteLine($"Kills: {participant.kills}");
                                Console.WriteLine($"Deaths: {participant.deaths}");
                                Console.WriteLine($"Assists: {participant.assists}");
                                Console.WriteLine($"Gold Earned: {participant.goldEarned}");
                                Console.WriteLine($"summonerspell1: {summonerspells[participant.summoner1Id]}");
                                Console.WriteLine($"summonerspell2: {summonerspells[participant.summoner2Id]}");
                                Console.WriteLine($"First Blood Kill: {participant.firstBloodKill}");
                                Console.WriteLine($"Damage Dealt to Buildings: {participant.damageDealtToBuildings}");
                                Console.WriteLine($"Game Ended in Surrender: {participant.gameEndedInSurrender}");
                                Console.WriteLine($"Largest Multi Kill: {participant.largestMultiKill}");
                                Console.WriteLine($"Longest Time Spent Living: {participant.longestTimeSpentLiving}");
                                Console.WriteLine($"Total Minions Killed: {participant.totalMinionsKilled}");
                                Console.WriteLine($"Total Damage Dealt to Champions: {participant.totalDamageDealtToChampions}");
                                Console.WriteLine($"Time CCing Others: {participant.timeCCingOthers}");
                                Console.WriteLine($"Detector Wards Placed: {participant.detectorWardsPlaced}");
                                Console.WriteLine($"Vision Score: {participant.visionScore}");
                                Console.WriteLine($"Win: {participant.win}");
                               

                                string rowData = $"{match.metadata.matchId},{match.info.gameCreation},{match.info.gameDuration},{match.info.gameMode},{queuestorage.queueIdDescriptionMap[match.info.queueId]},{match.info.gameType}{match.info.gameVersion}," +
                                        $"{participant.participantId},{participant.championName},{participant.kills},{participant.deaths}," +
                                        $"{participant.assists},{participant.goldEarned},{summonerspells[participant.summoner1Id]}," +
                                        $"{summonerspells[participant.summoner2Id]},{participant.firstBloodKill},{participant.damageDealtToBuildings}," +
                                        $"{participant.gameEndedInSurrender},{participant.largestMultiKill},{participant.longestTimeSpentLiving}," +
                                        $"{participant.totalMinionsKilled},{participant.totalDamageDealtToChampions},{participant.timeCCingOthers}," +
                                        $"{participant.detectorWardsPlaced},{participant.visionScore},{participant.win}";
                                writer.WriteLine(rowData);


                            }

                        }

                        Console.WriteLine();
                    }

                }
                catch (WebException ex)
                {
                    Console.WriteLine($"Error fetching data for match {matchId}: {ex.Message}");
                }
            }
        }
    }
    
}
// Define classes to represent API responses
public class PuuidResponse
{
    public string puuid { get; set; }
}

public class Match
{
    public Metadata metadata { get; set; }
    public Info info { get; set; }
}

public class Metadata
{
    public string matchId { get; set; }
}

public class Info
{
    public long gameCreation { get; set; }
    public long gameDuration { get; set; }
    public string gameMode { get; set; }
    public string gameVersion { get; set; }
    public string gameType { get; set; }
    
    public int queueId { get; set; }
    public List<Participant> participants { get; set; }
}

public class Participant
{
    public string puuid { get; set; }
    public int participantId { get; set; }
    public string championName { get; set; }
    public string riotIdName { get; set; }
    public int kills { get; set; }
    public int deaths { get; set; }
    public int assists { get; set; }
    public int goldEarned { get; set; }
    public bool win { get; set; }

    public bool firstBloodKill { get; set; }
    public int damageDealtToBuildings { get; set; }
    public bool gameEndedInSurrender { get; set; }
    public int largestMultiKill { get; set; }
    public int longestTimeSpentLiving { get; set; }
    public int totalMinionsKilled { get; set; }
    public int summoner1Id { get; set; }
    public int summoner2Id { get; set; }
    public int totalDamageDealtToChampions { get; set; }
    public int timeCCingOthers { get; set; }
    public int detectorWardsPlaced { get; set; }
    public int visionScore { get; set; }
    public int teamId { get; set; }


}


}
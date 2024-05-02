using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text.Json;

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

        // Process each match
        foreach (string matchId in matchIds)
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
                int myteamId = -1;
                List<Participant> relevantplayers = new List<Participant>();
                if (match.info.gameMode != "Aram")
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
                            Console.WriteLine($"Participant ID: {participant.participantId}");
                            Console.WriteLine($"Champion Name: {participant.championName}");
                            Console.WriteLine($"role: {participant.role}");
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

                            myteamId = participant.teamId;
                        }
                        else if (participant.puuid != puuid)
                        {
                            if (participant.role == "SUPPORT" || participant.role == "CARRY")
                            {
                                relevantplayers.Add(participant);
                            }
                        }
                    }
                    foreach (Participant player in relevantplayers)
                    {
                        if (player.role == "CARRY")
                        {
                            Console.WriteLine($"enemy adc is {player.championName}");
                        }
                        else if (player.role == "SUPPORT" && player.teamId == myteamId)
                        {
                            Console.WriteLine($"my support is {player.championName}");
                        }
                        else if ((player.role == "SUPPORT" && player.teamId != myteamId))
                        {
                            Console.WriteLine($"enemy support is {player.championName}");
                        }
                    }

                }
                Console.WriteLine();
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Error fetching data for match {matchId}: {ex.Message}");
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
    public int gameDuration { get; set; }
    public string gameMode { get; set; }
    public string gameVersion { get; set; }
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
    public string role { get; set; }
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



﻿/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string api_key = "RGAPI-4f16a338-efe0-4932-8160-5478bbedd0aa";
string username = "softfeathers";
string tagline = "euw";
string getpuuidurl = $"https://europe.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{username}/{tagline}?api_key={api_key}";
string softfeathers = "mcLV3IFaSOKhm2EqK3pYeNcnl0ZRNOWQzWx5RXihHQJYAFWnIHI5ljGMJkY4osQMWg0z-MZV-rX1Dg"; //obtained from above
string getrequesturlMatches = $"https://europe.api.riotgames.com/lol/match/v5/matches/by-puuid/{softfeathers}/ids?start=0&count=100&api_key={api_key}";
// below obtained from above. 
string[] matchid = {"EUW1_6924573866",
    "EUW1_6924552760",
    "EUW1_6924513284",
    "EUW1_6924496048",
    "EUW1_6924440601",
    "EUW1_6924379273",
    "EUW1_6924309311",
    "EUW1_6924279305",
    "EUW1_6923541515",
    "EUW1_6923484776",
    "EUW1_6923468240",
    "EUW1_6923447931",
    "EUW1_6923399042",
    "EUW1_6922449547",
    "EUW1_6922430542",
    "EUW1_6922397118",
    "EUW1_6922379870",
    "EUW1_6922353054",
    "EUW1_6915926483",
    "EUW1_6915874017",
    "EUW1_6915822541",
    "EUW1_6915763003",
    "EUW1_6915697135",
    "EUW1_6915658842",
    "EUW1_6915618762",
    "EUW1_6915555665",
    "EUW1_6915507566",
    "EUW1_6915480999",
    "EUW1_6915444436",
    "EUW1_6915371417",
    "EUW1_6915330326",
    "EUW1_6915305242",
    "EUW1_6915290407",
    "EUW1_6914995996",
    "EUW1_6914945804",
    "EUW1_6914870738",
    "EUW1_6914793452",
    "EUW1_6914768735",
    "EUW1_6914729981",
    "EUW1_6914703898",
    "EUW1_6914649858",
    "EUW1_6914612953",
    "EUW1_6913905848",
    "EUW1_6913808352",
    "EUW1_6913792688",
    "EUW1_6913773149",
    "EUW1_6913752670",
    "EUW1_6913739942",
    "EUW1_6913718182",
    "EUW1_6913690919",
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
    "EUW1_6910900543",
    "EUW1_6910858517",
    "EUW1_6910814201",
    "EUW1_6910769158",
    "EUW1_6910718623",
    "EUW1_6910643398",
    "EUW1_6910611671",
    "EUW1_6910564414",
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
    "EUW1_6906871398",
    "EUW1_6906844002",
    "EUW1_6906801401",
    "EUW1_6906776418",
    "EUW1_6906651686",
    "EUW1_6906633540",
    "EUW1_6906590425",
    "EUW1_6906565520",
    "EUW1_6906477065",
    "EUW1_6906433764"};

string[] MetaDataDTO = {
        "matchId",
        "participants",};
string[] InfoDTO = {
        "gameCreation",
        "gameDuration",
        "gameMode",
        "gameVersion",
        "participants"};
string[] participantDTO = {
        "assists",
        "kills",
        "deaths",
        "championName",
        "detectorWardsPlaced",
        "firstBloodKill",
        "damageDealtToBuildings",
        "gameEndedInSurrender",
        "goldEarned",
        "largestMultiKill",
        "longestTimeSpentLiving",
        "totalMinionsKilled",
        "participantId",
        "puuid",
        "riotIdName",
        "riotIdTagline",
        "summoner1Id",
        "summoner2Id",
        "totalDamageDealtToChampions",
        "timeCCingOthers",
        "visionScore",
        "win"    };
string[] apirequesturlgame = new string[matchid.Length];
for (int i = 0; i < matchid.Length; i++)
{
    apirequesturlgame[i] = $" https://europe.api.riotgames.com/lol/match/v5/matches/{matchid[i]}?api_key={api_key}";
}

class game
{

}*/
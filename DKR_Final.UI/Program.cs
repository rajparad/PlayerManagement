using System;
using System.Linq;
using DKR_Final.DataAccess;
using DKR_Final.DataModel;

namespace DKR_Final.UI
{
    class Program
    {
        private static DKR_Final_DB context = new DKR_Final_DB();

        
        static void Main(string[] args)
        {
            
        

           
          MainMenu();

          
        }

       
        private static void TeamMenu()
        {
             int i = 0;

            Console.WriteLine("\n---------------Team Menu---------------");
            Console.WriteLine("\nPress 1 to list all Teams along with team Players");
            Console.WriteLine("\nPress 2 to add a new team");
            Console.WriteLine("\nPress 3 to update an existing team");
            Console.WriteLine("\nPress 4 to delete an existing team");
            Console.WriteLine("\nPress 0 to return to main menu");

            int team = int.Parse(Console.ReadLine());
            switch (team)
            {
                case 1:
                    //list all Teams along with team players                
                    var res = context.Teams.Join(context.Players,
                        t => t.teamID,
                        p => p.teamId, (team, player) => new
                        {
                            id = team.teamID,
                            name = team.teamName,
                            manager = team.managerName,
                            player = player.playerName,
                            playerage = player.playerAge
                        });
                    Console.WriteLine("---------Team Detail--------");
                    Console.WriteLine("Team Id\tTeam Name\tTeam Manager\tPlayer Name\tPlayer Age");
                    foreach (var t in res)
                    {
                        Console.WriteLine(t.id + "\t" + t.name + "\t\t" + t.manager + "\t" + t.player +"\t\t" + t.playerage);
                    }
                    
                    break;
                case 2: 
                    //Add a new team

                    string tname;
                    Console.WriteLine("Enter Team Name:");
                    tname = Console.ReadLine();

                    string managername;
                    Console.WriteLine("Enter Manager Name:" );
                    managername = Console.ReadLine();

                    Team tadd = new Team { teamID = i++, teamName = tname, managerName = managername};
                    context.Teams.Add(tadd);
                    Console.WriteLine("Data is added!!!");

                    context.SaveChanges();
                    break;
                case 3: 
                    //update an existing team
                    
                    Console.WriteLine("Enter Team Name");
                    string abc = Console.ReadLine();
                    var tup = context.Teams.Where(uteam => uteam.teamName == abc).FirstOrDefault();

                    Console.WriteLine("Enter NewTeam Name");
                    string unewteam = Console.ReadLine();
                    tup.teamName = unewteam;

                    Console.WriteLine("Enter Manager Name");
                    string umname = Console.ReadLine();
                    tup.managerName = umname;

                    Console.WriteLine("Data is updated!!!");

                    context.SaveChanges();
                    break;
                case 4:
                    //delete an existing team
                    Console.WriteLine("Enter team Name");
                    string teamDel = Console.ReadLine();
                    var matcht = context.Teams.Where(uteam => uteam.teamName == teamDel).FirstOrDefault();
                    var tnew = context.Teams.Find(matcht.teamID);

                    Console.WriteLine("Data is removed!!!");
                    context.Teams.Remove(tnew);
                    context.SaveChanges();


                    break;
                case 0:
                    //return to main menu
                    MainMenu();
                    break;
            }
        }

        private static void PlayerMenu()
        {
            Console.WriteLine("\n-----------Player Menu-----------");
            Console.WriteLine("\nPress 1 to list all Players along with their teams");
            Console.WriteLine("\nPress 2 to add a new player");
            Console.WriteLine("\nPress 3 to update an existing player");
            Console.WriteLine("\nPress 4 to delete an existing player");
            Console.WriteLine("\nPress 5 to add an existing player to an existing team");
            Console.WriteLine("\nPress 0 to return to main menu");

            int player = int.Parse(Console.ReadLine());
            switch (player)
            {
              
                case 1: 
                    //list all players along with team
                    var res = context.Players.Join(context.Teams,
                        p => p.teamId,
                        t => t.teamID, (player, team) => new
                        {
                            id = player.playerID,
                            name = player.playerName,
                            age = player.playerAge,
                            team = team.teamName
                        }); ;
                    Console.WriteLine("---------Player Detail--------");
                    Console.WriteLine("Player Id\tPlayer Name\tPlayer Age\tTeam Name");

                    foreach (var t in res)
                    {
                        Console.WriteLine(t.id + "\t\t" + t.name + "\t\t" + t.age + "\t\t" + t.team);
                    }

                    break;
                case 2: 
                    //Add a new player
                    int i = 0;
                   

                    string pName;
                    Console.WriteLine("Enter Player Name:");
                    pName = Console.ReadLine();

                    int pAge;
                    Console.WriteLine("Enter Player Age:");
                    pAge = int.Parse(Console.ReadLine());



                    var c2res = context.Teams.ToList();
                    Console.WriteLine("\nTeam Id\tTeam Name\tManager Name");
                    foreach (var t in c2res)

                    {
  
                        Console.WriteLine(t.teamID + "\t" + t.teamName + "\t\t" + t.managerName);
                    }
                



                    int tId ;
                    Console.WriteLine("\nEnter Team Id which you want to join:");
                    tId = int.Parse(Console.ReadLine());

                    Player padd = new Player { playerID = i++, playerName = pName, playerAge = pAge, teamId = tId };
                    context.Players.Add(padd);
                    Console.WriteLine("\nPlayer is Added!!!!");
                    context.SaveChanges();


                    break;
                case 3: 
                    //update an existing player

                    Console.WriteLine("Enter Player's Name");
                    string name = Console.ReadLine();
                    var pup = context.Players.Where( p  => p.playerName == name).FirstOrDefault();

                    Console.WriteLine("Enter Player's New Name");
                    string unewplayer = Console.ReadLine();
                    pup.playerName = unewplayer;

                    Console.WriteLine("Enter Player's new Age");
                    int age  = int.Parse(Console.ReadLine());
                    pup.playerAge = age;

                    Console.WriteLine("\nPlayer's data is updated!!!!");

                    context.SaveChanges();

                    break;
                case 4:
                    //delete an existing player
                    Console.WriteLine("Enter Player's Name");
                    String playerDel = Console.ReadLine();

                    var matchp = context.Players.Where(p => p.playerName == playerDel).FirstOrDefault();
                    var pnew = context.Players.Find(matchp.playerID);

                    Console.WriteLine("\nPlayer is deleted!!!!");


                    context.Players.Remove(pnew);
                    context.SaveChanges();
                    break;
                case 5: 
                    //add an existing player to an existing team

                    Console.WriteLine("Enter Player's Name");
                    string c5name = Console.ReadLine();
                      var c5matchp = context.Players.Where(p => p.playerName == c5name).FirstOrDefault();

                    Console.WriteLine("Enter Team Id which you want to join?");
                    var c5res = context.Teams.ToList();
                    Console.WriteLine("\nTeam Id\tTeam Name\tManager Name");
                    foreach (var t in c5res)
                    {
                        Console.WriteLine(t.teamID + "\t" + t.teamName + "\t\t" + t.managerName);
                    }
                    Console.WriteLine("\n Team Id: ");
                    int c5tId = int.Parse(Console.ReadLine());
                    c5matchp.teamId = c5tId;


                    context.SaveChanges();

                    Console.WriteLine("\nYou have successfully joined the Team"+ c5matchp.teamId + "!!!!!");




                    break;
                case 0: 
                    //return to main menu
                    MainMenu();
                    break;
            }

        }

        private static void MainMenu()
        {
            bool begin = true;
            while (begin)
            {
                Console.WriteLine("\nWelcome, please choose a command:");
                Console.WriteLine("\nPress 1 to modify Team");
                Console.WriteLine("\nPress 2 to modify Player");
                Console.WriteLine("\nPress 0 to exit program");

                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        //Display Team Menu
                        TeamMenu();
                        break;
                    case 2:
                        //Display Player Menu
                        PlayerMenu();
                        break;
                    case 0:
                        return;


                }
            }
        }

    }
}

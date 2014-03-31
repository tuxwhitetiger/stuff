using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;


namespace server
{
    class database
    {
        //MySql.Data.MySqlClient.MySqlConnection conn;

        String serverIp = "127.0.0.1";
        String UserName = "root";
        String password = "Samsung2233";
        String schema = "disatation";

        public database()
        {
        }
/*
        public void connect() {
            string myConnectionString = 
                "server="+serverIp+
                ";uid="+UserName+
                ";pwd="+password+
                ";database="+schema+";";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            
        }
        */
        private MySql.Data.MySqlClient.MySqlConnection newConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection c;
            string myConnectionString =
                "server=" + serverIp +
                ";uid=" + UserName +
                ";pwd=" + password +
                ";database=" + schema + ";";
            c = new MySql.Data.MySqlClient.MySqlConnection();
            c.ConnectionString = myConnectionString;
            return c;
        }

        public void createNewUser(String UserName, String Password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO `disatation`.`users` (`UserName`, `password`) VALUES ('" + UserName + "', '" + Password + "');";
            
            command.ExecuteNonQuery();
            conn.Close();
        }
        public int doseUserExist(String UserName)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "SELECT * FROM `disatation`.`users` WHERE UserName='" + UserName + "';";
            
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {

                int i = Reader.FieldCount;
                conn.Close();
                return i;
            }
            conn.Close();
            return 0;
        }

        public void createNewcharacter(String userId, String charictorType, String CharictorName)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO `disatation`.`carictors` (`iduser`, `carictorsname`,`carictorstype`) VALUES ('" + userId + "', '" + CharictorName + "','" + charictorType + "');";
            
            command.ExecuteNonQuery();
            conn.Close();
        }

        public String fetchcharacter(int userId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM `carictors` Where `iduser` = '" + userId + "';";
            
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            String thisMessage = "";
            int j = 1;
            while (Reader.Read())
            {
                String thisrow = "char:"+j+":";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    thisrow += Reader.GetValue(i).ToString()+":";
                }
                MySql.Data.MySqlClient.MySqlConnection conn2 = newConnection();
                conn2.Open();
                MySqlCommand treedata = conn2.CreateCommand();
                treedata.CommandText = "SELECT * FROM `talents` WHERE `charictorID`='" + Reader.GetValue(0) + "'";
                MySqlDataReader Reader2;
                Reader2 = treedata.ExecuteReader();

                while (Reader2.Read())
                {
                    thisrow += "tree;";
                    for (int i = 0; i < Reader2.FieldCount; i++)
                    {
                        thisrow += Reader2.GetValue(i).ToString() + ";";
                    }
                }
                thisrow += ":";
                conn2.Close();

                conn2 = newConnection();
                conn2.Open();
                MySqlCommand armorData = conn2.CreateCommand();
                armorData.CommandText = "SELECT * FROM `charictorItems` WHERE `CharictorID`='" + Reader.GetValue(0) + "'";
                Reader2 = armorData.ExecuteReader();
                while (Reader2.Read())
                {
                    thisrow += "Item;";
                    for (int i = 0; i < Reader2.FieldCount; i++)
                    {
                        thisrow += Reader2.GetValue(i).ToString() + ";";
                    }
                }
                thisrow += ":";
                conn2.Close();

                thisMessage += thisrow;
                j++;
            }
            conn.Close();
            return thisMessage;
            //char:number of char:charID:userID:charname:cartype........
            
        }

        public int userlogin(String username, String password) {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "SELECT `idUsers` FROM `disatation`.`users` WHERE `username`='" + username + "' AND `password`='" + password + "';";
            
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                int thisrow = 0;
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    thisrow += int.Parse(Reader.GetValue(i).ToString());
                }
                if (thisrow != 0) {
                    conn.Close();
                    return thisrow;
                }
            }
            conn.Close();
            return 0;
        }

        internal void updateCharictorsTalentPoints(int charictorID, int talentpoints)
        {

            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE `disatation`.`carictors` SET `aviliableTalentPoints`='"+talentpoints+"' WHERE `idcarictors`='"+charictorID+"';";
            command.ExecuteNonQuery();
            conn.Close();

        }
        internal void updateCharictorsAddTalent(int charictorID, int treenumber,int x, int y, int level)
        {

            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO `disatation`.`talents` (`charictorID`, `treenumber`, `x`, `y`, `level`) VALUES ('" + charictorID + "', '" + treenumber + "', '" + x + "', '" + y + "', '" + level + "');";
            command.ExecuteNonQuery();
            conn.Close();

        }


        internal void updateCharictorXP(int charictorDBid2, int exp)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE `disatation`.`carictors` SET `experiance`='"+exp+"' WHERE `idcarictors`='" + charictorDBid2 + "';";
            command.ExecuteNonQuery();
            conn.Close();
        }

        internal void updateCharictorLevel(int charictorDBid3, int level)
        {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE `disatation`.`carictors` SET `level`='" + level + "' WHERE `idcarictors`='" + charictorDBid3 + "';";
            command.ExecuteNonQuery();
            conn.Close();
        }

        internal void equipItemFromInventory(int charictorID, int ItemToEquipDBID, int itemToInventoryDBID)
        {
            bool update = false;

            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            MySqlDataReader Reader;
            command.CommandText = "SELECT * FROM `disatation`.`charictoritems` WHERE `CharictorID` = '" + charictorID + "' AND `idCharictorItems`='" + itemToInventoryDBID + "';";

            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.FieldCount > 0) { 
                    update = true;
                    break;
                }
            }
            conn.Close();

            MySql.Data.MySqlClient.MySqlConnection conn2 = newConnection();
            conn2.Open();
            MySqlCommand command2 = conn2.CreateCommand();
            if(update){//if there is an item in the armor slot
                command2.CommandText = "UPDATE `disatation`.`charictoritems` SET `Equiped`='1' WHERE `CharictorID` = '" + charictorID + "' AND `idCharictorItems`='" + ItemToEquipDBID + "';";
                command2.ExecuteNonQuery();
                //inventory is now item to inventory
                command2.CommandText = "UPDATE `disatation`.`charictoritems` SET `Equiped`='0' WHERE `CharictorID` = '" + charictorID + "' AND `idCharictorItems`='" + itemToInventoryDBID + "';";
                command2.ExecuteNonQuery();
            }else{
                command2.CommandText = "UPDATE `disatation`.`charictoritems` SET `Equiped`='1' WHERE `CharictorID` = '" + charictorID + "' AND `idCharictorItems`='" + ItemToEquipDBID + "';";
                command2.ExecuteNonQuery();
            }
            conn2.Close();
        }

        internal void pickupitem(int charictorID, int itemToInventoryID) {
            MySql.Data.MySqlClient.MySqlConnection conn = newConnection();
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO `disatation`.`charictorItems` (`ItemID`, `CharictorID`, `Equiped`) VALUES ('" + itemToInventoryID + "','" + charictorID + "',0);";
            command.ExecuteNonQuery();
        }
    }
}

﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace WiiUSmash4.BusinessLogic
{
    public static class FighterDataProvider
    {
        public static DataSet GetFighters()
        {
            DataSet dataSet = new DataSet();

            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.GetFighterIds, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    SqlDataAdapter adapter = new SqlDataAdapter
                    {
                        SelectCommand = command
                    };

                    connection.Open();
                    adapter.Fill(dataSet);
                }
            }
            return dataSet;
        }

        public static DataSet GetFighter(int fighterId)
        {
            DataSet dataSet = new DataSet();

            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.GetFighter, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Fighter_Id, fighterId));

                    SqlDataAdapter adapter = new SqlDataAdapter
                    {
                        SelectCommand = command
                    };

                    connection.Open();
                    adapter.Fill(dataSet);
                }
            }
            return dataSet;
        }

        public static int InsertPartialFighter(Fighter fighter)
        {
            int fighterId = 0;
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertFighter, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Fighter_TableType, FighterTableBuilder.BuildFighterPartialTable(fighter)));

                    connection.Open();
                    fighterId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return fighterId;
        }

        public static void InsertAttributes(int fighterId, Attributes attributes)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertAttributes, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Attributes_TableType, FighterTableBuilder.BuildAttributesTable(fighterId, attributes)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertAerial(int fighterId, Aerial aerial)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertAerial, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Aerial_TableType, FighterTableBuilder.BuildAerialTable(fighterId, aerial)));
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.AbilityFramePicture_TableType, FighterTableBuilder.BuildAbilityFrameTable(aerial.AbilityFramePictureUrls)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertAttack(int fighterId, Attack attack)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertAttack, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Attack_TableType, FighterTableBuilder.BuildAttackTable(fighterId, attack)));
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.AbilityFramePicture_TableType, FighterTableBuilder.BuildAbilityFrameTable(attack.AbilityFramePictureUrls)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertGrab(int fighterId, Grab grab)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertGrab, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Grab_TableType, FighterTableBuilder.BuildGrabTable(fighterId, grab)));
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.AbilityFramePicture_TableType, FighterTableBuilder.BuildAbilityFrameTable(grab.AbilityFramePictureUrls)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertRoll(int fighterId, Roll roll)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertRoll, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Roll_TableType, FighterTableBuilder.BuildRollTable(fighterId, roll)));
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.AbilityFramePicture_TableType, FighterTableBuilder.BuildAbilityFrameTable(roll.AbilityFramePictureUrls)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertSpecial(int fighterId, Special special)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertSpecial, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Special_TableType, FighterTableBuilder.BuildSpecialTable(fighterId, special)));
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.AbilityFramePicture_TableType, FighterTableBuilder.BuildAbilityFrameTable(special.AbilityFramePictureUrls)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertThrow(int fighterId, Throw throwAbility)
        {
            using (var connection = new SqlConnection(DatabaseDefines.SmashDbConnectionString))
            {
                using (var command = new SqlCommand(DatabaseDefines.InsertThrow, connection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.Throw_TableType, FighterTableBuilder.BuildThrowTable(fighterId, throwAbility)));
                    command.Parameters.Add(new SqlParameter(DatabaseDefines.AbilityFramePicture_TableType, FighterTableBuilder.BuildAbilityFrameTable(throwAbility.AbilityFramePictureUrls)));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

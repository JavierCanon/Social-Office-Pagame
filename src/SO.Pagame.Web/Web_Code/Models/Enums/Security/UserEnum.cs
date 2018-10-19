namespace Pagame.Models.Enum.Security
{

    /// <summary>
    /// Enum for clasificated user interactions
    /// </summary>
    public enum UserActionsEnum
    {
        Access,
        Delete,
        Insert,
        Update
    }



    /// <summary>
    /// Internal Roles, the user created roles are handled in db
    /// </summary>
    public enum UserRolEnum
    {
        /// <summary>
        /// low security checkin
        /// </summary>
        Administrator = 2
        ,
        /// <summary>
        /// No valid enum for search for string value
        /// </summary>
        NoValidEnum = -1
        ,
        /// <summary>
        /// max security checkin
        /// </summary>
        Operator = 4,
        /// <summary>
        /// no security checkin
        /// </summary>
        SuperAdministrator = 1
        ,
        /// <summary>
        /// medium security checkin
        /// </summary>
        Supervisor = 3
        ,
        /// <summary>
        /// no security checkin
        /// </summary>
        System = 0
    }




}
namespace Common.Common;

/// <summary>
/// Indicates the status of the health of the current system.
/// </summary>
public enum StatusHealth
{
    OK = 0,
    Maintenance,
    Issue,
    Critical
}

/// <summary>
/// Defines the role of a person in the society.
/// </summary>
public enum SocietyRoleType
{
    Member = 0,
    Owner,
    Tenant,
    SubManager,
    Manager,
    SecurityStaff,
    HouseKeepingStaff
}

public enum AmenityType
{
    Gym = 0,
    SwimmingPoolIndoor,
    SwimmingPoolOutdoor,
    CommonAmenitiesMen,
    CommonAmenitiesWomen
}   
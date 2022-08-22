using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Vehicl_Project.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Vehicle_ProjectUser class
public class Vehicle_ProjectUser : IdentityUser
{
    public string FullName { get; set; }
    public string Role { get; set; }
}


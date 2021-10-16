<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="EPiServer.ServiceLocation" %>
<%@ Import Namespace="EPiServer.Shell.Security" %>

<%
    var roles = new[] {
     "Administrator",
     "Administrators",
     "CmsAdmins",
     "CmsEditors",
     "WebAdmins",
     "WebEditors",
    };
    const string username = "demo";
    const string password = "Pass@word123!";
    const string email = "admin@localhost.com";

    var status = UIUserCreateStatus.Success;
    List<string> errorList = null;

    var userProvider = ServiceLocator.Current.GetInstance<UIUserProvider>();
    var roleProvider = ServiceLocator.Current.GetInstance<UIRoleProvider>();

    var result = userProvider.GetUser(username.ToLower());
    var existed = result != null;

    if (result == null) {
        var errors = Enumerable.Empty<string>();

        result = userProvider.CreateUser(
        username.ToLower(),
        password,
        email,
        null,
        null,
        true,
        out status,
        out errors);

        if (errors != null)
        {
            errorList = errors.ToList();
        }
    }

    if (result != null)
    {
        var existedRoles = roleProvider
            .GetRolesForUser(result.Username)
            .ToList();

        foreach (var role in roles)
        {
            if (!roleProvider.RoleExists(role))
                roleProvider.CreateRole(role);

            if (!existedRoles.Contains(role))
                roleProvider.AddUserToRoles(result.Username, new[] { role });
        }

        %>
            <p>Done!</p>
            <p>User: <%= result.Username %></p>
            <p>Pass: <%= existed ? "(old password)" : password %></p>
        <%
    }
    else
    {
        %>
            <p>Error! <%= status %></p>
        <%

        if (errorList != null)
        {
            foreach (var error in errorList)
            {
                %>
                    <p><%= error %></p>
                <%
            }
        }
    }
%>

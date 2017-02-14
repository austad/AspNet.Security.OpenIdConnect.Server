/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OpenIdConnect.Server
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using System.Collections.Generic;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Owin.Security.OpenIdConnect.Server
{
    /// <summary>
    /// An event raised before the authorization server handles
    /// the request made to the token introspection endpoint.
    /// </summary>
    public class HandleIntrospectionRequestContext : BaseValidatingContext
    {
        /// <summary>
        /// Creates an instance of this context.
        /// </summary>
        public HandleIntrospectionRequestContext(
            IOwinContext context,
            OpenIdConnectServerOptions options,
            OpenIdConnectRequest request,
            AuthenticationTicket ticket)
            : base(context, options, request)
        {
            Ticket = ticket;
            Validate();
        }

        /// <summary>
        /// Gets or sets the authentication ticket.
        /// </summary>
        public AuthenticationTicket Ticket { get; set; }

        /// <summary>
        /// Gets the additional claims returned to the caller.
        /// </summary>
        public IDictionary<string, OpenIdConnectParameter> Claims { get; } =
            new Dictionary<string, OpenIdConnectParameter>(StringComparer.Ordinal);

        /// <summary>
        /// Gets or sets the flag indicating
        /// whether the token is active or not.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets the list of audiences returned to the caller
        /// as part of the "aud" claim, if applicable.
        /// </summary>
        public ISet<string> Audiences { get; } =
            new HashSet<string>(StringComparer.Ordinal);

        /// <summary>
        /// Gets or sets the "exp" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public DateTimeOffset? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the "iat" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public DateTimeOffset? IssuedAt { get; set; }

        /// <summary>
        /// Gets or sets the "iss" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the "nbf" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Gets or sets the "scope" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the "sub" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the "jti" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public string TokenId { get; set; }

        /// <summary>
        /// Gets or sets the "token_type" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the "username" claim
        /// returned to the caller, if applicable.
        /// </summary>
        public string Username { get; set; }
    }
}

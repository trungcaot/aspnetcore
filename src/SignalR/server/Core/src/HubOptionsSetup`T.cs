// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.SignalR
{
    public class HubOptionsSetup<THub> : IConfigureOptions<HubOptions<THub>> where THub : Hub
    {
        private readonly HubOptions _hubOptions;
        public HubOptionsSetup(IOptions<HubOptions> options)
        {
            _hubOptions = options.Value;
        }

        public void Configure(HubOptions<THub> options)
        {
            // Do a deep copy, otherwise users modifying the HubOptions<THub> list would be changing the global options list
            options.SupportedProtocols = new List<string>(_hubOptions.SupportedProtocols ?? Array.Empty<string>());
            options.KeepAliveInterval = _hubOptions.KeepAliveInterval;
            options.HandshakeTimeout = _hubOptions.HandshakeTimeout;
            options.ClientTimeoutInterval = _hubOptions.ClientTimeoutInterval;
            options.EnableDetailedErrors = _hubOptions.EnableDetailedErrors;
            options.MaximumReceiveMessageSize = _hubOptions.MaximumReceiveMessageSize;
            options.StreamBufferCapacity = _hubOptions.StreamBufferCapacity;
            options.MaxParallelInvocationsPerClient = _hubOptions.MaxParallelInvocationsPerClient;

            options.UserHasSetValues = true;

            if (_hubOptions.HubFilters != null)
            {
                options.HubFilters = new List<IHubFilter>(_hubOptions.HubFilters);
            }
        }
    }
}

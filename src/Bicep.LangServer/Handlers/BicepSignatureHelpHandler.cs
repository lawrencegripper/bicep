// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Bicep.LanguageServer.Utils;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace Bicep.LanguageServer.Handlers
{
    public class BicepSignatureHelpHandler: SignatureHelpHandler
    {
        public BicepSignatureHelpHandler() : base(CreateRegistrationOptions())
        {
        }

        public override Task<SignatureHelp?> Handle(SignatureHelpParams request, CancellationToken cancellationToken)
        {
            return Task.FromResult<SignatureHelp?>(new SignatureHelp
            {
                Signatures = new Container<SignatureInformation>(
                    new SignatureInformation
                    {
                        Label = "foo",
                        Documentation = new StringOrMarkupContent(new MarkupContent
                        {
                            Kind = MarkupKind.Markdown,
                            Value = "Foos the `foo` on the other `foo`."
                        }),
                        Parameters = new Container<ParameterInformation>(
                            new ParameterInformation
                            {
                                Label = new ParameterInformationLabel("one"),
                                Documentation = new StringOrMarkupContent(new MarkupContent
                                {
                                    Kind = MarkupKind.Markdown,
                                    Value = "The first `foo`"
                                })
                            })
                    })
            });
        }

        private static SignatureHelpRegistrationOptions CreateRegistrationOptions() => new SignatureHelpRegistrationOptions
        {
            DocumentSelector = DocumentSelectorFactory.Create(),
            TriggerCharacters = new Container<string>("("),
            RetriggerCharacters = new Container<string>(",")
        };
    }
}

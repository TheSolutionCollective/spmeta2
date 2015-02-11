﻿using System.Linq;
using SPMeta2.Containers.Assertion;
using SPMeta2.CSOM.ModelHandlers;
using SPMeta2.CSOM.ModelHosts;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Utils;

namespace SPMeta2.Regression.CSOM.Validation
{
    public class ClientListFieldLinkDefinitionValidator : ListFieldLinkModelHandler
    {
        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var listModelHost = modelHost.WithAssertAndCast<ListModelHost>("modelHost", value => value.RequireNotNull());
            var definition = model.WithAssertAndCast<ListFieldLinkDefinition>("model", value => value.RequireNotNull());

            var list = listModelHost.HostList;
            var context = list.Context;

            var spObject = list.Fields.GetById(definition.FieldId);
            context.Load(spObject, o => o.Id);
            context.ExecuteQuery();

            var assert = ServiceFactory.AssertService
                                      .NewAssert(definition, spObject)
                                            .ShouldNotBeNull(spObject)
                                            .ShouldBeEqual(m => m.FieldId, o => o.Id);

            if (definition.AddFieldOptions.HasFlag(BuiltInAddFieldOptions.DefaultValue))
            {
                assert.SkipProperty(m => m.AddFieldOptions, "BuiltInAddFieldOptions.DefaultValue. Skipping.");
            }
            else
            {
                // TODO
            }

            if (definition.AddToDefaultView)
            {
                assert.ShouldBeEqual((p, s, d) =>
                {
                    var srcProp = s.GetExpressionValue(m => m.AddToDefaultView);

                    var field = list.Fields.GetById(definition.FieldId);
                    var defaultView = list.DefaultView;

                    context.Load(defaultView);
                    context.Load(defaultView, v => v.ViewFields);

                    context.Load(field);
              
                    context.ExecuteQuery();

                    var isValid = list.DefaultView
                        .ViewFields
                        .Contains(field.InternalName);

                    return new PropertyValidationResult
                    {
                        Tag = p.Tag,
                        Src = srcProp,
                        Dst = null,
                        IsValid = isValid
                    };
                });
            }
            else
            {
                assert.SkipProperty(m => m.AddToDefaultView, "AddToDefaultView is false. Skipping.");
            }
        }
    }
}

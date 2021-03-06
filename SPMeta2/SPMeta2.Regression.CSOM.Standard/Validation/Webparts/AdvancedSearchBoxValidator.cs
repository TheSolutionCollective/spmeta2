using System;
using SPMeta2.CSOM.ModelHandlers;
using SPMeta2.CSOM.ModelHandlers.Webparts;
using SPMeta2.CSOM.ModelHosts;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Regression.CSOM.Validation;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Utils;
using SPMeta2.Containers.Assertion;

namespace SPMeta2.Regression.CSOM.Standard.Validation.Webparts
{
    public class AdvancedSearchBoxValidator : WebPartDefinitionValidator
    {
        public override Type TargetType
        {
            get { return typeof(AdvancedSearchBoxDefinition); }
        }

        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            base.DeployModel(modelHost, model);

            var listItemModelHost = modelHost.WithAssertAndCast<ListItemModelHost>("modelHost", value => value.RequireNotNull());
            var definition = model.WithAssertAndCast<AdvancedSearchBoxDefinition>("model", value => value.RequireNotNull());

            var pageItem = listItemModelHost.HostListItem;

            WithExistingWebPart(listItemModelHost.HostFile, definition, spObject =>
            {
                var assert = ServiceFactory.AssertService
                                           .NewAssert(model, definition, spObject)
                                                 .ShouldNotBeNull(spObject);

                if (!string.IsNullOrEmpty(definition.AndQueryTextBoxLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.AndQueryTextBoxLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("AndQueryTextBoxLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.AndQueryTextBoxLabelText);
                }

                if (!string.IsNullOrEmpty(definition.DisplayGroup))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.DisplayGroup);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("DisplayGroup");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.DisplayGroup);
                }


                if (!string.IsNullOrEmpty(definition.LanguagesLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.LanguagesLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("LanguagesLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.LanguagesLabelText);
                }

                if (!string.IsNullOrEmpty(definition.NotQueryTextBoxLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.NotQueryTextBoxLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("NotQueryTextBoxLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.NotQueryTextBoxLabelText);
                }

                if (!string.IsNullOrEmpty(definition.OrQueryTextBoxLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.OrQueryTextBoxLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("OrQueryTextBoxLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.OrQueryTextBoxLabelText);
                }

                if (!string.IsNullOrEmpty(definition.PhraseQueryTextBoxLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.PhraseQueryTextBoxLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("PhraseQueryTextBoxLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.PhraseQueryTextBoxLabelText);
                }


                if (!string.IsNullOrEmpty(definition.AdvancedSearchBoxProperties))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.AdvancedSearchBoxProperties);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("Properties");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.AdvancedSearchBoxProperties);
                }

                if (!string.IsNullOrEmpty(definition.PropertiesSectionLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.PropertiesSectionLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("PropertiesSectionLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.PropertiesSectionLabelText);
                }


                if (!string.IsNullOrEmpty(definition.ResultTypeLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ResultTypeLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ResultTypeLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.ResultTypeLabelText);
                }

                if (!string.IsNullOrEmpty(definition.ScopeLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ScopeLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ScopeLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.ScopeLabelText);
                }

                if (!string.IsNullOrEmpty(definition.ScopeSectionLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ScopeSectionLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ScopeSectionLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.ScopeSectionLabelText);
                }

                if (!string.IsNullOrEmpty(definition.SearchResultPageURL))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.SearchResultPageURL);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("SearchResultPageURL");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.SearchResultPageURL);
                }

                if (definition.ShowAndQueryTextBox.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowAndQueryTextBox);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowAndQueryTextBox");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowAndQueryTextBox);
                }

                if (definition.ShowLanguageOptions.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowLanguageOptions);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowLanguageOptions");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowLanguageOptions);
                }


                if (definition.ShowNotQueryTextBox.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowNotQueryTextBox);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowNotQueryTextBox");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowNotQueryTextBox);
                }

                if (definition.ShowOrQueryTextBox.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowOrQueryTextBox);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowOrQueryTextBox");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowOrQueryTextBox);
                }

                if (definition.ShowPhraseQueryTextBox.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowPhraseQueryTextBox);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowPhraseQueryTextBox");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowPhraseQueryTextBox);
                }


                if (definition.ShowPropertiesSection.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowPropertiesSection);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowPropertiesSection");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowPropertiesSection);
                }


                if (definition.ShowResultTypePicker.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowResultTypePicker);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowResultTypePicker");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowResultTypePicker);
                }

                if (definition.ShowScopes.HasValue)
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.ShowScopes);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("ShowScopes");

                        var isValid = ConvertUtils.ToBool(value) == ConvertUtils.ToBool(srcProp.Value);

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
                    assert.SkipProperty(m => m.ShowScopes);
                }


                if (!string.IsNullOrEmpty(definition.TextQuerySectionLabelText))
                {
                    assert.ShouldBeEqual((p, s, d) =>
                    {
                        var srcProp = s.GetExpressionValue(m => m.TextQuerySectionLabelText);
                        var value = CurrentWebPartXml.GetAdvancedSearchBoxWebPartProperty("TextQuerySectionLabelText");

                        var isValid = value == srcProp.Value.ToString();

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
                    assert.SkipProperty(m => m.TextQuerySectionLabelText);
                }
            });
        }
    }
}

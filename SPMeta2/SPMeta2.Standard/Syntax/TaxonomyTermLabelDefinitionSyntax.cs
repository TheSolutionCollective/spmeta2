﻿using System;
using SPMeta2.Models;
using SPMeta2.Standard.Definitions.Taxonomy;
using SPMeta2.Syntax.Default.Extensions;

namespace SPMeta2.Standard.Syntax
{
    public static class TaxonomyTermLabelDefinitionSyntax
    {
        public static ModelNode AddTaxonomyTermLabel(this ModelNode model, TaxonomyTermLabelDefinition definition)
        {
            return AddTaxonomyTermLabel(model, definition, null);
        }

        public static ModelNode AddTaxonomyTermLabel(this ModelNode model, TaxonomyTermLabelDefinition definition, Action<ModelNode> action)
        {
            return model.AddDefinitionNode(definition, action);
        }
    }
}

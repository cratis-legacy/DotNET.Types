﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Einar Ingebrigtsen. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace Cratis.Types.Specs.for_ContractToImplementorsMap
{
    public class when_asking_for_implementors_of_type_by_generic_without_implementors : given.an_empty_map
    {
        static IEnumerable<Type> result;

        Because of = () => result = map.GetImplementorsFor<IInterface>();

        It should_not_have_any_implementors = () => result.ShouldBeEmpty();
    }
}

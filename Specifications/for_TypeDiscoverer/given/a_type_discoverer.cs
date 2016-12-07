﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Cratis.Types;
using Cratis.Assemblies;
using Machine.Specifications;
using Moq;

namespace Cratis.Types.Specs.for_TypeDiscoverer.given
{
    public class a_type_discoverer
    {
        protected static TypeDiscoverer type_discoverer;
        protected static Mock<Assembly> assembly_mock;
        protected static Type[] types;

        protected static Mock<IAssemblies> assemblies_mock;
        protected static Mock<ITypeFinder> type_finder_mock;
        protected static Mock<IContractToImplementorsMap> contract_to_implementors_map_mock;

        Establish context = () =>
                                {
                                    types = new[] {
                                        typeof(ISingle),
                                        typeof(Single),
                                        typeof(IMultiple),
                                        typeof(FirstMultiple),
                                        typeof(SecondMultiple)
                                    };

                                    assembly_mock = new Mock<Assembly>();
                                    assembly_mock.Setup(a => a.GetTypes()).Returns(types);
                                    assembly_mock.Setup(a => a.FullName).Returns("A.Full.Name");

                                    assemblies_mock = new Mock<IAssemblies>();
                                    assemblies_mock.Setup(x => x.GetAll()).Returns(new[] { assembly_mock.Object });

                                    contract_to_implementors_map_mock = new Mock<IContractToImplementorsMap>();

                                    type_finder_mock = new Mock<ITypeFinder>();
                                    type_discoverer = new TypeDiscoverer(assemblies_mock.Object, type_finder_mock.Object, contract_to_implementors_map_mock.Object);
                                };
    }
}
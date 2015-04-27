using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Plugly.Tests
{
    [TestClass]
    public class SerializationTests : TestsBase
    {
        [TestMethod]
        public void Serialization_Binary()
        {
            customizer.Setup<SerializableAddress>()
                .ExtendWith<SerializableExtension>();

            var address = customizer.CreateInstance<SerializableAddress>();
            address.ShouldBeAssignableTo<ISerializableExtension>();
            
            var addressType = address.GetType();
            addressType.GetCustomAttributes(typeof(SerializableAttribute), false).ShouldNotBeEmpty();
            var ext = (ISerializableExtension)address;
            ext.PhoneNumber = "#";

            var binary = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                binary.Serialize(ms, address);
                ms.Position = 0;
                ext = (ISerializableExtension)binary.Deserialize(ms);
                ext.PhoneNumber.ShouldBe("#");
            }
        }

        [Serializable]
        public class SerializableAddress
        {
            public string Country { get; set; }
        }

        [Serializable]
        class SerializableExtension : ISerializableExtension
        {
            public string PhoneNumber { get; set; }
        }

        public interface ISerializableExtension
        {
            string PhoneNumber { get; set; }
        }

        [TestMethod]
        public void Serialization_DataContract()
        {
            customizer.Setup<DataContractAddress>()
                .ExtendWith<DataContractExtension>();

            var address = customizer.CreateInstance<DataContractAddress>();
            address.ShouldBeAssignableTo<IDataContractExtension>();
            ((IDataContractExtension)address).PhoneNumber = "#";

            var addressType = address.GetType();
            addressType.GetCustomAttributes(typeof(DataContractAttribute), false).ShouldNotBeEmpty();
            addressType.GetProperty("PhoneNumber").GetCustomAttributes(typeof(DataMemberAttribute), false).ShouldNotBeEmpty();

            var dataContractSerializer = new DataContractSerializer(addressType);
            using (var ms = new System.IO.MemoryStream())
            {
                dataContractSerializer.WriteObject(ms, address);
                ms.Position = 0;
                var xml = new StreamReader(ms).ReadToEnd();
                xml.ShouldStartWith("<Address ");
                xml.ShouldContain("<PhoneNumber");
                ms.Position = 0;
                dataContractSerializer.ReadObject(ms);
            }
        }

        [DataContract(Name = "Address", Namespace = "")]
        public class DataContractAddress
        {
            [DataMember]
            public string Country { get; set; }
        }

        class DataContractExtension : IDataContractExtension
        {
            public string PhoneNumber { get; set; }
        }

        public interface IDataContractExtension
        {
            [DataMember]
            string PhoneNumber { get; set; }
        }
    }
}

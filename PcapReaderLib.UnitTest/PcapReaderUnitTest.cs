using System.IO;
using System.Reflection;

namespace PcapReaderLib.UnitTest
{
	[TestClass]
	public class PcapReaderUnitTest
	{
		/*[TestMethod]
		public void ConstructorShouldThrowExceptionIfParameterIsNull()
		{
#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new PcapReader(null));
#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}*/

		[DataTestMethod]
		[DataRow("PcapReaderLib.UnitTest.TestFiles.file1.pcap")]
		public void ReadHeaderShouldReturnValidHeader(string ResourceName)
		{
			FileHeader? header;
			IPcapReader reader;


			reader = new PcapReader();
			using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName))
			{
				if (stream == null) Assert.Fail("Resource not found");
				using (BinaryReader binaryReader = new BinaryReader(stream))
				{

					header = reader.ReadHeader(binaryReader);

					Assert.IsNotNull(header);
					Assert.AreEqual(0xA1B2C3D4, header.MagicNumber);
					Assert.AreEqual(2, header.MajorVersion);
					Assert.AreEqual(4, header.MinorVersion);
					Assert.AreNotEqual<uint>(0, header.SnapLen);
					Assert.AreEqual<uint>(1, header.LinkType);
				}
			}

		}
		[DataTestMethod]
		[DataRow("PcapReaderLib.UnitTest.TestFiles.file1.pcap")]
		public void ReadHRecordShouldReturnValidRecord(string ResourceName)
		{
			PacketRecord? record;
			FileHeader header;
			IPcapReader reader;

			reader = new PcapReader();
			using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName))
			{
				if (stream == null) Assert.Fail("Resource not found");
				using (BinaryReader binaryReader = new BinaryReader(stream))
				{

					// skip header
					header=reader.ReadHeader(binaryReader);

					record = reader.ReadPacketRecord(binaryReader);

					Assert.IsNotNull(record);
					Assert.AreEqual<UInt32>(1711096725, record.TimestampSeconds);
					Assert.AreEqual<UInt32>(145911, record.TimestampMicroOrNanoSeconds);
					Assert.AreEqual<UInt32>(786, record.CapturedPacketLength);
					Assert.AreEqual<UInt32>(786, record.OriginalPacketLength);
					Assert.AreEqual(786, record.PacketData.Length);
					Assert.AreEqual(new DateTime(2024,3,22,8,38,45,145,911), header.GetTimeTimeUTC(record));
				}
			}

		}


	}
}
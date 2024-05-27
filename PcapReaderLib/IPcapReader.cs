using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapReaderLib
{
	public interface IPcapReader
	{
		FileHeader ReadHeader(BinaryReader Reader);
		PacketRecord ReadPacketRecord(BinaryReader Reader);

	}
}

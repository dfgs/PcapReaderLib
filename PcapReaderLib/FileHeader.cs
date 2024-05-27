using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapReaderLib
{
	public class FileHeader:PcapBlock
	{
		public uint MagicNumber
		{
			get;
			set;
		}
		public ushort MajorVersion
		{
			get;
			set;
		}
		public ushort MinorVersion
		{
			get;
			set;
		}

		public uint Reserved1
		{
			get;
			set;
		}
		public uint Reserved2
		{
			get;
			set;
		}

		public uint SnapLen
		{
			get;
			set;
		}

		public uint LinkType
		{
			get;
			set;
		}

		public byte FCS
		{
			get;
			set;
		}
		
		public FileHeader()
		{

		}




	}
}

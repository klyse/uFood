using System;
using MongoDB.Bson;

namespace uFood.ServiceLayer.MongoDB
{
	public static class IDHelper
	{
		public static ObjectId? GetObjectId(this string id)
		{
			try
			{
				return new ObjectId(id);
			}
			catch (Exception)
			{
				// ignored
			}

			return null;
		}
	}
}
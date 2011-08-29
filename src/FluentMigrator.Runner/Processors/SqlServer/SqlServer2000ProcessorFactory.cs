#region License

// 
// Copyright (c) 2007-2009, Sean Chambers <schambers80@gmail.com>
// Copyright (c) 2010, Nathan Brown
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

#endregion

namespace FluentMigrator.Runner.Processors.SqlServer
{
	using System;
	using System.Data.SqlClient;
	using Generators.SqlServer;

	public class SqlServer2000ProcessorFactory : MigrationProcessorFactory
	{
		public override IMigrationProcessor Create(string connectionString, IAnnouncer announcer, IMigrationProcessorOptions options)
		{
			var factory = new SqlClientDbFactory();
			var connection = factory.CreateConnection(connectionString);
			return new SqlServerProcessor(connection, new SqlServer2000Generator(), announcer, options, factory);
		}
	}

	public class SqlClientDbFactory : DbFactoryBase
	{
		public SqlClientDbFactory() : base(SqlClientFactory.Instance)
		{
		}
	}
}
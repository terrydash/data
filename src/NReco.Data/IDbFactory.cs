#region License
/*
 * NReco Data library (http://www.nrecosite.com/)
 * Copyright 2016 Vitaliy Fedorchenko
 * Distributed under the MIT license
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace NReco.Data
{

	/// <summary>
	/// Represents factory for creating db-specific ADO.NET component implementations.
	/// </summary>
	public interface IDbFactory {

		/// <summary>
		/// Create command 
		/// </summary>
		IDbCommand CreateCommand();

		/// <summary>
		/// Create connection 
		/// </summary>
		IDbConnection CreateConnection();

		/// <summary>
		/// Add new constant parameter
		/// </summary>
		CommandParameter AddCommandParameter(IDbCommand cmd, object value);

		/// <summary>
		/// Creare SQL builder
		/// </summary>
		ISqlExpressionBuilder CreateSqlBuilder(IDbCommand dbCommand, Func<Query,string> buildSubquery);

		/// <summary>
		/// Get ID of last inserted record
		/// </summary>
		object GetInsertId(IDbConnection connection);
	}

	public sealed class CommandParameter {
		public string Placeholder { get; private set; }
		public IDbDataParameter Parameter { get; private set; }

		public CommandParameter(string placeholder, DbParameter dbParam) {
			Placeholder = placeholder;
			Parameter = dbParam;
		}
	}

}

using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek
{
    public class Database
    {
        // TODO try to convert into only once connecting (instead of connecting again for every query)

        public IDriver Driver { get; set; } // stores driver

        /// <summary>
        /// Connect to database and run a query string
        /// </summary>
        /// <param name="query">Query to run</param>
        /// <returns>Result from database</returns>
        public async Task<List<INode>> ConnectDb(string query)
        {
            // TODO get auth params from some config file
            Driver = CreateDriverWithBasicAuth("bolt://localhost:11003", "neo4j", "1234"); // connect to database
            List<INode> res = new List<INode>(); // create list to store results in
            IAsyncSession session = Driver.AsyncSession(o => o.WithDatabase("neo4j")); // start session

            // try to start transaction with query proved. Return results
            try {
                res = await session.ReadTransactionAsync(async tx => {
                    var results = new List<INode>();
                    var reader = await tx.RunAsync(query);

                    while (await reader.FetchAsync()) { results.Add(reader.Current[0].As<INode>()); }

                    return results; // return results
                });
            } finally {
                await session.CloseAsync(); // close session
            }

            return res; // return results

        }


        /// <summary>
        /// Create graph database driver
        /// </summary>
        /// <param name="uri">Url of database</param>
        /// <param name="Person">Personname for login</param>
        /// <param name="password">Password for login</param>
        /// <returns>Driver</returns>
        public IDriver CreateDriverWithBasicAuth(string uri, string Person, string password)
        {
            return GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(Person, password));
        }
    }
}

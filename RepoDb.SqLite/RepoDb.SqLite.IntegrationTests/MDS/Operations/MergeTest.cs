﻿using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoDb.SqLite.IntegrationTests.Models;
using RepoDb.SqLite.IntegrationTests.Setup;
using System.Linq;

namespace RepoDb.SqLite.IntegrationTests.Operations.MDS
{
    [TestClass]
    public class MergeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Database.Initialize();
            Cleanup();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Database.Cleanup();
        }

        #region DataEntity

        #region Sync

        [TestMethod]
        public void TestSqLiteConnectionMergeForIdentityForEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();

                // Act
                var result = connection.Merge<MdsCompleteTable>(table);
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertPropertiesEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeForIdentityForNonEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();

                // Setup
                Helper.UpdateMdsCompleteTableProperties(table);

                // Act
                var result = connection.Merge<MdsCompleteTable>(table);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertPropertiesEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeForIdentityForNonEmptyTableWithQualifiers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var qualifiers = new[]
                {
                    new Field("Id", typeof(long))
                };
                Helper.UpdateMdsCompleteTableProperties(table);
                table.ColumnInt = 0;
                table.ColumnChar = "C";

                // Act
                var result = connection.Merge<MdsCompleteTable>(table,
                    qualifiers);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertPropertiesEquality(table, queryResult.First());
            }
        }

        #endregion

        #region Async

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncForIdentityForEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();

                // Act
                var result = connection.MergeAsync<MdsCompleteTable>(table).Result;
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertPropertiesEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncForIdentityForNonEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();

                // Setup
                Helper.UpdateMdsCompleteTableProperties(table);

                // Act
                var result = connection.MergeAsync<MdsCompleteTable>(table).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertPropertiesEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncForIdentityForNonEmptyTableWithQualifiers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var qualifiers = new[]
                {
                    new Field("Id", typeof(long))
                };
                Helper.UpdateMdsCompleteTableProperties(table);
                table.ColumnInt = 0;
                table.ColumnChar = "C";

                // Act
                var result = connection.MergeAsync<MdsCompleteTable>(table,
                    qualifiers).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertPropertiesEquality(table, queryResult.First());
            }
        }

        #endregion

        #endregion

        #region TableName

        #region Sync

        [TestMethod]
        public void TestSqLiteConnectionMergeViaTableNameForIdentityForEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();

                // Act
                var result = connection.Merge(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    table);
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeViaTableNameForIdentityForNonEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                Helper.UpdateMdsCompleteTableProperties(table);

                // Act
                var result = connection.Merge(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    table);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeViaTableNameForIdentityForNonEmptyTableWithQualifiers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var qualifiers = new[]
                {
                    new Field("Id", typeof(long))
                };
                Helper.UpdateMdsCompleteTableProperties(table);
                table.ColumnInt = 0;
                table.ColumnChar = "C";

                // Act
                var result = connection.Merge(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    table,
                    qualifiers);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsDynamicViaTableNameForIdentityForEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Create the tables
                Database.CreateMdsTables(connection);

                // Setup
                var table = Helper.CreateMdsCompleteTablesAsDynamics(1).First();

                // Act
                var result = connection.Merge(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    (object)table);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsDynamicViaTableNameForIdentityForNonEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var obj = new
                {
                    table.Id,
                    ColumnInt = int.MaxValue
                };

                // Act
                var result = connection.Merge(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    (object)obj);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.IsTrue(queryResult.Count() > 0);
                Assert.AreEqual(obj.ColumnInt, queryResult.First().ColumnInt);
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsDynamicViaTableNameForIdentityForNonEmptyTableWithQualifiers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var obj = new
                {
                    table.Id,
                    ColumnInt = int.MaxValue
                };
                var qualifiers = new[]
                {
                    new Field("Id", typeof(long))
                };

                // Act
                var result = connection.Merge(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    (object)obj,
                    qualifiers);

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.IsTrue(queryResult.Count() > 0);
                Assert.AreEqual(obj.ColumnInt, queryResult.First().ColumnInt);
            }
        }

        #endregion

        #region Async

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncViaTableNameForIdentityForEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();

                // Act
                var result = connection.MergeAsync(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    table).Result;
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncViaTableNameForIdentityForNonEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                Helper.UpdateMdsCompleteTableProperties(table);

                // Act
                var result = connection.MergeAsync(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    table).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncViaTableNameForIdentityForNonEmptyTableWithQualifiers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var qualifiers = new[]
                {
                    new Field("Id", typeof(long))
                };
                Helper.UpdateMdsCompleteTableProperties(table);

                // Act
                var result = connection.MergeAsync(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    table,
                    qualifiers).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncAsDynamicViaTableNameForIdentityForEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Create the tables
                Database.CreateMdsTables(connection);

                // Setup
                var table = Helper.CreateMdsCompleteTablesAsDynamics(1).First();

                // Act
                var result = connection.MergeAsync(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    (object)table).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.AreEqual(1, queryResult?.Count());
                Helper.AssertMembersEquality(table, queryResult.First());
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncAsDynamicViaTableNameForIdentityForNonEmptyTable()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var obj = new
                {
                    table.Id,
                    ColumnInt = int.MaxValue
                };

                // Act
                var result = connection.MergeAsync(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    (object)obj).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.IsTrue(queryResult.Count() > 0);
                Assert.AreEqual(obj.ColumnInt, queryResult.First().ColumnInt);
            }
        }

        [TestMethod]
        public void TestSqLiteConnectionMergeAsyncAsDynamicViaTableNameForIdentityForNonEmptyTableWithQualifiers()
        {
            using (var connection = new SqliteConnection(Database.ConnectionStringMDS))
            {
                // Setup
                var table = Database.CreateMdsCompleteTables(1, connection).First();
                var obj = new
                {
                    table.Id,
                    ColumnInt = int.MaxValue
                };
                var qualifiers = new[]
                {
                    new Field("Id", typeof(long))
                };

                // Act
                var result = connection.MergeAsync(ClassMappedNameCache.Get<MdsCompleteTable>(),
                    (object)obj,
                    qualifiers).Result;

                // Assert
                Assert.AreEqual(table.Id, result);

                // Act
                var queryResult = connection.Query<MdsCompleteTable>(result);

                // Assert
                Assert.IsTrue(queryResult.Count() > 0);
                Assert.AreEqual(obj.ColumnInt, queryResult.First().ColumnInt);
            }
        }

        #endregion

        #endregion
    }
}


#from py2neo import authenticate, Graph

# set up authentication parameters
#authenticate("localhost:7474", "user", "pass")

# connect to authenticated graph database
#sgraph = Graph("http://localhost:7474/db/data/")

from neo4j import GraphDatabase

driver = GraphDatabase.driver("bolt://localhost:7687", auth=("neo4j", "password"))

def add_friend(tx, name, friend_name):
    tx.run("MERGE (a:Person {name: $name}) "
           "MERGE (a)-[:KNOWS]->(friend:Person {name: $friend_name})",
           name=name, friend_name=friend_name)

def print_friends(tx, name):
    for record in tx.run("MATCH (a:Person)-[:KNOWS]->(friend) WHERE a.name = $name "
                         "RETURN friend.name ORDER BY friend.name", name=name):
        print(record["friend.name"])

with driver.session() as session:
    session.write_transaction(add_friend, "Arthur", "Guinevere")
    session.write_transaction(add_friend, "Arthur", "Lancelot")
    session.write_transaction(add_friend, "Arthur", "Merlin")
    session.read_transaction(print_friends, "Arthur")


#q = 'MATCH (u:User)-[r:likes]->(m:Beer) WHERE u.name="Marco" RETURN u, type(r), m'
# "db" as defined above
q= "MATCH (n:Person)" "RETURN n.name;"

def test (tx, n):
	tx.run("MATCH (n:Person)" "RETURN n.name;")
	print("n.name") 

with driver.session() as session:
	session.read_transaction(test, "n")
	nodes = session.run(q)





print("List:")

for node in nodes:
    #print(node)
    print(node["n.name"])
#results = driver.query(q, returns=(client.Node, str, client.Node))
#for r in results:
#    print("(%s)-[%s]->(%s)" % (r[0]["name"], r[1], r[2]["name"]))
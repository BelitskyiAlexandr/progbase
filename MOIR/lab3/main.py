from elasticsearch import Elasticsearch
from datetime import datetime


es = Elasticsearch([{'host': 'localhost', 'port': 9200, 'scheme': 'http'}])

# 
index_name = 'test-index'
if not es.indices.exists(index=index_name):
    es.indices.create(index=index_name)

#
mapping = {
    "properties": {
        "name": {"type": "keyword"},
        "date": {"type": "date"},
        "participants": {"type": "keyword"},
        "revenue": {"type": "integer"}
    }
}
es.indices.put_mapping(index=index_name, body=mapping)

def create_document(name, date, participants, revenue):
    doc = {
        "name": name,
        "date": date,
        "participants": participants,
        "revenue": revenue
    }
    es.index(index=index_name, body=doc)

def read_documents():
    query = {"query": {"match_all": {}}}
    results = es.search(index=index_name, body=query)
    return results['hits']['hits']

def delete_document(doc_id):
    es.delete(index=index_name, id=doc_id)


while True:
    print("\nOptions:")
    print("1. Create a new document")
    print("2. Read all documents")
    print("3. Delete a document")
    print("4. Exit")
    choice = input("Enter your choice: ")

    if choice == '1':
        name = input("Enter document name: ")
        date = input("Enter document date (YYYY-MM-DD): ")
        participants = input("Enter participants: ")
        revenue = int(input("Enter revenue: "))
        create_document(name, date, participants, revenue)
        print("Document created successfully!")

    elif choice == '2':
        documents = read_documents()
        print("\nAll Documents:")
        for doc in documents:
            print("ID:", doc['_id'])
            print("Name:", doc['_source']['name'])
            print("Date:", doc['_source']['date'])
            print("Participants:", doc['_source']['participants'])
            print("Revenue:", doc['_source']['revenue'])
            print("")

    elif choice == '3':
        doc_id = input("Enter document ID to delete: ")
        delete_document(doc_id)
        print("Document deleted successfully!")

    elif choice == '4':
        break

    else:
        print("Invalid choice! Please enter a valid option.")

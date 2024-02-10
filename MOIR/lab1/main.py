# index terms
def read_index_terms_from_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        index_terms = file.readlines()
    index_terms = [term.strip() for term in index_terms]
    return index_terms

file_path = input("Enter path to the file with index terms: ")
index_terms = read_index_terms_from_file(file_path)
print("Set of the index terms:", index_terms)

#docs
import os

def read_documents_from_directory(directory_path):
    documents = []
    for filename in os.listdir(directory_path):
        if filename.endswith('.txt'):
            with open(os.path.join(directory_path, filename), 'r') as file:
                document_content = file.read()
                documents.append(document_content)
    return documents


directory_path = input("Enter path to derictory with docs: ")
documents = read_documents_from_directory(directory_path)
print("Number of docs:", len(documents))

#search
def execute_search_query(index_terms, documents):
    while True:
        query = input("Enter a search term or 'exit' to exit: ")
        if query.lower() == 'exit':
            break
        query_terms = query.split()  # Splitting a query into terms
        relevant_documents = []
        for i, document in enumerate(documents):
            relevant_terms = []
            for term in query_terms:
                if term in index_terms and term in document:
                    relevant_terms.append(term)
            if relevant_terms:
                relevant_documents.append((i + 1, relevant_terms, document))
        if relevant_documents:
            print("Relevant documents for the request '{}':".format(query))
            for doc_info in relevant_documents:
                print("Document №{}:".format(doc_info[0]))
                print("Relevant terms:", doc_info[1])
                print("Content of the document:", doc_info[2])
        else:
            print("There is no relevant documents for the query '{}'.\n".format(query)) 


execute_search_query(index_terms, documents)

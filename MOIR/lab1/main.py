# index terms
def read_index_terms_from_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        index_terms = file.readlines()
    index_terms = [term.strip() for term in index_terms]
    return index_terms

#file_path = input("Enter path to the file with index terms: ")
file_path = 'lab1/index_terms.txt'
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


#directory_path = input("Enter path to derictory with docs: ")
directory_path = "lab1/docs_for_lab"
documents = read_documents_from_directory(directory_path)
print("Number of docs:", len(documents))

#search
'''
import re

# search
def execute_search_query(index_terms, documents):
    while True:
        query = input("Enter the search query or 'exit' to quit: ")
        if query.lower() == 'exit':
            break
        
        # dis
        disjunctions = query.split('^')
        
        relevant_documents = set()
        for disjunction in disjunctions:
            conjunctions = disjunction.split('*')
            relevant_docs_for_disjunction = set(range(1, len(documents) + 1))
            for conjunction in conjunctions:
                # terms with ! and without
                terms_with_negation = re.findall(r'(!?\w+)', conjunction)
                required_terms = set()
                excluded_terms = set()
                for term in terms_with_negation:
                    if term.startswith('!'):
                        excluded_terms.add(term[1:])  # Відсутні терми
                    else:
                        required_terms.add(term)  # Терми, які повинні бути в документі
                # search
                relevant_docs_for_conjunction = set()
                for i, document in enumerate(documents):
                    # terms in doc
                    if all(term in document for term in required_terms):
                        # !terms not in doc
                        if not any(term in document for term in excluded_terms):
                            relevant_docs_for_conjunction.add(i + 1)
                relevant_docs_for_disjunction &= relevant_docs_for_conjunction
            relevant_documents |= relevant_docs_for_disjunction
        
        # print
        if relevant_documents:
            print("Relevant documents for the query '{}':".format(query))
            for doc_index in relevant_documents:
                print("Document #{}:".format(doc_index))
                print("Relevant terms:", query)
                print("Document content:", documents[doc_index - 1])
        else:
            print("No relevant documents found for the query '{}'.\n".format(query))


execute_search_query(index_terms, documents)

'''

#search
def execute_search_query(index_terms, documents):
    while True:
        query = input("Enter the search query or 'exit' to quit: ")
        if query.lower() == 'exit':
            print("Exiting...")
            break
        
        # query for disjunc parts
        disjunctions = query.split('^')
        
        relevant_documents = set()
        for disjunction in disjunctions:
            conjunctions = disjunction.split('*')
            relevant_docs_for_disjunction = set(range(1, len(documents) + 1))
            for conjunction in conjunctions:
                # search in each part of disjuncs
                relevant_docs_for_conjunction = set()
                for i, document in enumerate(documents):
                    if all(term.strip() in document for term in conjunction.split()):
                        relevant_docs_for_conjunction.add(i + 1)
                relevant_docs_for_disjunction &= relevant_docs_for_conjunction
            relevant_documents |= relevant_docs_for_disjunction
        
        # print
        if relevant_documents:
            print("---\nRelevant documents for the query '{}':".format(query))
            for doc_index in relevant_documents:
                print("Document #{}:".format(doc_index))
                print("Relevant terms:", query)
                print("Document content:", documents[doc_index - 1])
                print("---\n")
        else:
            print("No relevant documents found for the query '{}'.\n".format(query))


execute_search_query(index_terms, documents)


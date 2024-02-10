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
import re

def execute_search_query(index_terms, documents):
    while True:
        query = input("Enter a search term or 'exit' to exit: ")
        #query = "fox ^ foxes * dog"
        if query.lower() == 'exit':
            break
        query_terms = re.split(r'[\s^*]+', query)  # Splitting a query into terms without '^','*'
        relevant_documents = []
        for i, document in enumerate(documents):
            relevant_terms = []
            for term in query_terms:
                if term in index_terms and term in document:
                    relevant_terms.append(term)
            if relevant_terms:
                relevant_documents.append((i + 1, relevant_terms, document))
        
        ''' #block of expression process
        i = 0
        wanted_docs = []
        terms = query.split()
        while i < len(terms) - 1:
            if terms[i + 1] == '^':
                for item in relevant_documents:
                    document_index, relevant_terms, document_text = item
                    for term in relevant_terms:
                        if terms[i + 2] == term:
                            wanted_docs.append(item)
                i += 2
                continue;
            if terms[i + 1] == '*':
                buf_list = []
                for item in relevant_documents:
                    document_index, relevant_terms, document_text = item
                    for term in relevant_terms:
                        if terms[i + 2] == term:
                            wanted_docs.append(item)
                for item in wanted_docs:
                    document_index, relevant_terms, document_text = item
                    if term not in relevant_terms:
                        wanted_docs.remove(item)
                i += 2
                continue;
        '''
        #block of print
        if relevant_documents:
            print("\nRelevant documents for the request '{}':".format(query))
            for doc_info in relevant_documents:
                print("---\nDocument №{}:".format(doc_info[0]))
                print("Relevant terms:", doc_info[1])
                print("Content of the document:\n", doc_info[2])
                print('---\n')
        else:
            print("There is no relevant documents for the query '{}'.\n".format(query)) 
        

execute_search_query(index_terms, documents)

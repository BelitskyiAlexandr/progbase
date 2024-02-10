
def read_index_terms_from_file(file_path):
    with open(file_path, 'r', encoding='utf-8') as file:
        index_terms = file.readlines()
    index_terms = [term.strip() for term in index_terms]
    return index_terms

file_path = input("Enter path to the file with index terms: ")
index_terms = read_index_terms_from_file(file_path)
print("Set of the index terms:", index_terms)

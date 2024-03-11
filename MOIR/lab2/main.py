import os
import math
from collections import Counter
import string

def preprocess_text(text):
    translator = str.maketrans('', '', string.punctuation)
    text = text.translate(translator)  # Remove punctuation
    text = text.lower()  # Convert to lowercase
    return text

def compute_tf(documents):
    tf_dict = {}
    for doc in documents:
        words = preprocess_text(doc).split()
        word_count = Counter(words)
        tf = {word: word_count[word] for word in word_count}
        tf_dict[doc] = tf
    
    return tf_dict

def compute_idf(documents):
    total_docs = len(documents)
    word_doc_count = {}
    for doc in documents:
        words = preprocess_text(doc).split()
        for word in words:
            word_doc_count[word] = word_doc_count.get(word, 0) + 1

    idf = {word: math.log(total_docs / (count + 1)) for word, count in word_doc_count.items()}
    return idf

def compute_tf_idf_vectors(documents, idf):
    tf_idf_vectors = []
    
    for doc in documents:
        doc_tf = compute_tf([doc])[doc]  # Compute TF for the current document
        tf_idf_vector = {word: tf * idf.get(word, 0) for word, tf in doc_tf.items()}
        tf_idf_vectors.append(tf_idf_vector)
        
    return tf_idf_vectors

def compute_cosine_similarity(query, tf_idf_vector):
    scalar_product = sum(query.get(word, 0) * tf_idf_vector.get(word, 0) for word in set(query) & set(tf_idf_vector))
    
    query_length = math.sqrt(sum(value ** 2 for value in query.values()))
    tf_idf_length = math.sqrt(sum(value ** 2 for value in tf_idf_vector.values()))
    
    cosine_similarity = scalar_product / (query_length * tf_idf_length) if (query_length * tf_idf_length) != 0 else 0
    
    return cosine_similarity

def read_documents_from_directory(directory):
    documents = []
    for filename in os.listdir(directory):
        with open(os.path.join(directory, filename), 'r', encoding='utf-8') as file:
            documents.append(file.read())
    return documents

def main():
    directory = input("Enter the directory path containing the documents: ")
    directory = "docs_for_lab"
    documents = read_documents_from_directory(directory)

    idf = compute_idf(documents)

    while True:
        # Read search query from user
        query = input("Enter the search query or exit: ")
        if query == 'exit':
            break

        query_tf = compute_tf([query])[query]
        tf_idf_vectors = compute_tf_idf_vectors(documents, idf)
        
        similarities = [compute_cosine_similarity(query_tf, tf_idf_vector) for tf_idf_vector in tf_idf_vectors]

        for i, similarity in enumerate(similarities):
            print(f"Document {i+1}: Cosine Similarity = {similarity}")


if __name__ == "__main__":
    main()

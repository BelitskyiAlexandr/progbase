import os
import math
from collections import Counter
from itertools import combinations
from scipy.spatial import distance

def read_documents(directory):
    documents = {}
    file_list = os.listdir(directory)
    for filename in file_list:
        with open(os.path.join(directory, filename), 'r', encoding='utf-8') as file:
            documents[filename] = file.read()
    return documents

def calculate_tf(text):
    word_count = Counter(text.split())
    total_words = len(text.split())
    tf = {word: count / total_words for word, count in word_count.items()}
    return tf

def calculate_idf(documents):
    total_documents = len(documents)
    idf = {}
    all_words = [word for document in documents.values() for word in set(document.split())]
    for word in all_words:
        count = sum(1 for document in documents.values() if word in document)
        idf[word] = math.log(total_documents / count)
    return idf

def calculate_tf_idf(tf, idf):
    tf_idf = {word: tf_value * idf[word] for word, tf_value in tf.items()}
    return tf_idf

def cosine_similarity(vector1, vector2):
    return 1 - distance.cosine(list(vector1.values()), list(vector2.values()))


#main
directory = input("Enter the path to the directory with the documents: ")
documents = read_documents(directory)

idf = calculate_idf(documents)

while True:
    query = input("Enter query: ")
    query_tf = calculate_tf(query)
    query_tf_idf = calculate_tf_idf(query_tf, idf)

    similarities = {}
    for doc_name, doc_content in documents.items():
        doc_tf = calculate_tf(doc_content)
        doc_tf_idf = calculate_tf_idf(doc_tf, idf)
        similarity = cosine_similarity(query_tf_idf, doc_tf_idf)
        similarities[doc_name] = similarity

    sorted_similarities = sorted(similarities.items(), key=lambda x: x[1], reverse=True)
    
    print("\nSearch results:")
    for doc_name, similarity in sorted_similarities:
        print(f"Doc: {doc_name}, Similarity: {similarity:.4f}")
    
    choice = input("\nDo you want to make a new query? (Y/N): ").lower()
    if choice != 'y':
        break

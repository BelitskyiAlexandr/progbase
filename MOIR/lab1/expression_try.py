expression = 'fox ^ foxes * dog'

document_index, relevant_terms, document = 0, "t", "t"

terms = expression.split()
i = 0
wanted_doc = [(document_index, relevant_terms, document)]
while i < len(terms) - 1:
    if terms[i + 1] == '^':
        wanted_doc.append(terms[i].doc) 
        wanted_doc.append(terms[i + 2].doc)
        i += 2
    if terms[i + 1] == '*':
        buf_list = []
        for item in wanted_doc:
            document_index, relevant_terms, document = item
            for term in relevant_terms:
                if terms[i + 2] == term:
                    buf_list.append(item)
        i += 2

from google_images_download import google_images_download   #importing the library

response = google_images_download.googleimagesdownload()   #class instantiation

arguments = {"keywords":"radish, potato, eggplant, cauliflower, celery,"
                        "apple, pear, orange, grapefruit, banana,"
                        "oats, rice, bread, pizza, pasta,"
                        "salmon meat, beef, poultry meat, steak, pork meat,"
                        "yogurt, chocolate, ice cream, cake, pie","limit":20,"print_urls":True}

paths = response.download(arguments)   #passing the arguments to the function
print(paths)
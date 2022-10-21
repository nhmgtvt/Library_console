// Phase 2 
// An implementation of MovieCollection ADT
// 2022


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in a binary search tree 
public class BTreeNode
{
    private IMovie movie; // movie
    private BTreeNode lchild; // reference to its left child 
    private BTreeNode rchild; // reference to its right child

    public BTreeNode(IMovie movie)
    {
        this.movie = movie;
        lchild = null;
        rchild = null;
    }

    public IMovie Movie
    {
        get { return movie; }
        set { movie = value; }
    }

    public BTreeNode LChild
    {
        get { return lchild; }
        set { lchild = value; }
    }

    public BTreeNode RChild
    {
        get { return rchild; }
        set { rchild = value; }
    }
}

// invariant: no duplicates in this movie collection
public class MovieCollection : IMovieCollection
{
    private BTreeNode root; // movies are stored in a binary search tree and the root of the binary search tree is 'root' 
    private int count; // the number of (different) movies currently stored in this movie collection 



    // get the number of movies in this movie colllection 
    // pre-condition: nil
    // post-condition: return the number of movies in this movie collection and this movie collection remains unchanged
    public int Number { get { return count; } }

    // constructor - create an object of MovieCollection object
    public MovieCollection()
    {
        root = null;
        count = 0;
    }

    // Check if this movie collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this movie collection is empty; otherwise, return false.
    public bool IsEmpty()
    {
        //To be completed
        if (count == 0)
            return true;
        else
            return false;
    }

    // Insert a movie into this movie collection
    // Pre-condition: nil
    // Post-condition: the movie has been added into this movie collection and return true, if the movie is not in this movie collection; otherwise, the movie has not been added into this movie collection and return false.
    public bool Insert(IMovie movie)
    {
        //To be completed
        bool result = true;
        BTreeNode newNode = new BTreeNode(movie);
        if (root == null)
        {
            root = newNode;
            count++;
            return true;
        }
        else
        {
            BTreeNode current = root;
            BTreeNode parent;
            while (true)
            {
                parent = current;
                bool testExisted = false;
                if (movie.CompareTo(current.Movie) == 0)
                    testExisted = true;
                if (current.LChild != null && movie.CompareTo(current.LChild.Movie) == 0)
                    testExisted = true;
                if (current.RChild != null && movie.CompareTo(current.RChild.Movie) == 0)
                    testExisted = true;
                if (testExisted)
                {
                    Console.WriteLine("Movie is not added, movie alread exists!");
                    return false;
                }
                if (movie.CompareTo(current.Movie) < 0)
                {
                    current = current.LChild;
                    if (current == null)
                    {
                        parent.LChild = newNode;
                        break;
                    }
                }
                else
                {
                    current = current.RChild;
                    if (current == null)
                    {
                        parent.RChild = newNode;
                        break;
                    }
                }
            }
            count++;
            return result;
        }
    }

    private IMovie minValue(BTreeNode node)
    {
        IMovie result = node.Movie;
        while (node.LChild != null)
        {
            result = node.LChild.Movie;
            node = node.LChild;
        }
        return result;
    }

    private BTreeNode deleteNode(BTreeNode node, IMovie movie)
    {
        if (node == null)
            return node;
        if (movie.CompareTo(node.Movie) < 0)
            node.LChild = deleteNode(node.LChild, movie);
        else if (movie.CompareTo(node.Movie) > 0)
            node.RChild = deleteNode(node.RChild, movie);
        else //found
        {
            
            if (node.LChild == null)
            {
                count--;
                return node.RChild;
            }
            else if (node.RChild == null)
            {
                count--;
                return node.LChild;
            }
                
            node.Movie = minValue(node.RChild);

            node.RChild = deleteNode(node.RChild, node.Movie);
            
        }
        return node;
    }

    // Delete a movie from this movie collection
    // Pre-condition: nil
    // Post-condition: the movie is removed out of this movie collection and return true, if it is in this movie collection; return false, if it is not in this movie collection
    public bool Delete(IMovie movie)
    {
        bool result = true;
        if (count == 0 || root == null)
            return false;
        root = deleteNode(root, movie);
        
        return result;
    }

    // Search for a movie in this movie collection
    // pre: nil
    // post: return true if the movie is in this movie collection;
    //	     otherwise, return false.

    public bool Search(IMovie movie)
    {
        //To be completed
        if (count == 0)
            return false;
        IMovie searchResult = Search(movie.Title);
        return searchResult == null ? false : true;
    }

    // Search for a movie by its title in this movie collection  
    // pre: nil
    // post: return the reference of the movie object if the movie is in this movie collection;
    //	     otherwise, return null.
    public IMovie Search(string movietitle)
    {
        BTreeNode node = root;
        while (node != null && node.Movie.Title.CompareTo(movietitle) != 0)
        {
            if (movietitle.CompareTo(node.Movie.Title) < 0)
                node = node.LChild;
            else
                node = node.RChild;
        }
        return node == null ? null : node.Movie;
    }

    private void GetMoviesInOrder(ref IMovie[] movies, BTreeNode current, ref int position)
    {
        if (current.LChild != null)
            GetMoviesInOrder(ref movies, current.LChild, ref position);
        movies[position++] = current.Movie;
        if (current.RChild != null)
            GetMoviesInOrder(ref movies, current.RChild, ref position);
    }

    // Store all the movies in this movie collection in an array in the dictionary order by their titles
    // Pre-condition: nil
    // Post-condition: return an array of movies that are stored in dictionary order by their titles
    public IMovie[] ToArray()
    {
        //To be completed
        IMovie[] result = new IMovie[count];
        int i = 0;
        GetMoviesInOrder(ref result, root, ref i);
        return result;
    }



    // Clear this movie collection
    // Pre-condotion: nil
    // Post-condition: all the movies have been removed from this movie collection 
    public void Clear()
    {
        root = null;
        count = 0;
    }
}






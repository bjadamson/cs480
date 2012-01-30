// Author: Benjamin Adamson
// Class: CS480 - Milestone 1

#include <stdio.h>
#include <stdlib.h>

#define n 4
#define max_depth 2

struct node {
	struct node *parent;
	struct node *children;
	int visited;
} node;

static int global_value = 1;

void visit_child_nodes(struct node *p)
{
	// loop iterator
	int i = 0;

	// base case, is leaf-node
	if(p->children == NULL) {
		p->visited = 1;
		fprintf(stdout, "%d\n", p->visited);
		return;
	}

	// non-leaf
	for(i = 0; i < n; ++i)
	{
		visit_child_nodes(p->children + i);
	}

	// visit the non-leaf node (post-order)
	p->visited = 1;
	fprintf(stdout, "%d\n", p->visited);
}

void init_tree(struct node *p, unsigned int depth)
{
	// loop iterator
	int i = 0;

	p->visited = 0;

	if(depth == max_depth) {
		p->children = NULL;
		return;
	}

	p->children = (struct node*)malloc(sizeof(struct node) * n);
	for(i = 0; i < n; ++i) {
		init_tree(&p->children[i], depth+1);
	}
}

int main(int argc, char *argv[])
{
	struct node root;

	init_tree(&root, 0);
	visit_child_nodes(&root);

	return 0;
}

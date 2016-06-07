$(document).ready(function() {
  // drawLine('#l00t');
  let tree;
  $('#btn-create').click(function() {
    var a = $("#array-key").val().split(',');

    a = $.map(a, function(item) {
      return parseInt(item, 10);
    })

    buildTreeFromArray(a).done(function(data) {
      tree = data.value;
      drawTree(tree);
      showTreeInfo(tree)
    });
  });
  $('#btn-insert').click(function() {
    if (!$('#insert-key').val()) {
      alert("Please enter a key");
      return;
    }
    insertX(tree, parseInt($('#insert-key').val(), 10)).done(function(response) {
      if (response.http_status === 200) {
        insertNode($('#insert-key').val(), tree);
        tree = response.value;
      }
      else if (response.http_status === 409) { 
        alert(response.message);
      }
    })
    
  });
  $('#btn-find').click(function() {
    if (!$('#find-key').val()) {
      alert("Please enter a key");
      return;
    }
    findNode($('#find-key').val(), tree);
  });
  $('#btn-get-max').click(function() {
    getMax(tree);
  });
  $('#btn-get-min').click(function() {
    getMin(tree);
  });
  $('#btn-min-right').click(function() {
    getMinOfRight(tree);
  });
  $('#btn-max-left').click(function() {
    getMaxOfLeft(tree);
  });
  $('#btn-delete').click(function() {
    if (!$('#delete-key').val()) {
      alert("Please enter a key");
      return;
    }
    deleteNode($('#delete-key').val(), tree);
  });
  $('#btn-show-order').click(function() {
    // showOrderLNR(tree.left, tree);
    if ($('#order-value').val() == "L-N-R") {
      showOrderLNR(tree);
    }
    if ($('#order-value').val() == "N-L-R") {
      showOrderNLR(tree);
    }
    if ($('#order-value').val() == "L-R-N") {
      showOrderLRN(tree);
    }
  });
   $('#btn-clear').click(function() {
    clearTree(tree);
  });
  ////////////////////////////// draw tree //////////////////////////////
  function drawTree(tree) {
    drawTreeLine(tree);
    drawTreeNode(tree);
  }

  function drawTreeNode(tree) { // ve node cua cay
    if (tree == null) {
      return;
    }
    drawNode(tree, '#666');
    drawTree(tree.left);
    drawTree(tree.right);
  }

  function drawTreeLine(tree) { // ve line cua cay
    if (tree == null) {
      return;
    }
    drawLine(tree, tree.left, '#666');
    drawLine(tree, tree.right, '#666');
    drawTreeLine(tree.left);
    drawTreeLine(tree.right);
  }

  function SVG(tag) { // tao doi tuong
    return document.createElementNS('http://www.w3.org/2000/svg', tag);
  }
  var center = 360;
  // draw functions
  // draw node
  function getFirstX(level) { // lay x cua node dau tien moi level
    return (center / Math.pow(2, level));
  }

  function createText(str) { // tao text trong node
    var newText = SVG('text');
    newText.setAttributeNS(null, "x", 0);
    newText.setAttributeNS(null, "y", 5);
    var textNode = document.createTextNode(str);
    newText.appendChild(textNode);
    return newText;
  }

  function getXNode(node) { // lay toa do x cua node
    return getFirstX(node.level) * (2 * node.order - 1);
  }

  function getYNode(node) { // lay toa do y cua node
    return 40 + (100 * node.level);
  }

  function drawNode(node, color) { // ve node
    // tinh toa do
    let x = getXNode(node);
    let y = getYNode(node);
    let $svg = $('#svgPanel');
    let $g = $(SVG('g')).attr('transform', "translate(" + x + "," + y + ")");
    let $circle = $(SVG('circle')).attr('cx', 0).attr('cy', 0).attr('r', 22.5).attr('fill', '#FFF').attr('stroke', color).attr('stroke-width', 3).appendTo($g);
    let $text = $(createText(node.key)).attr("style", "z-index: 2; fill: #666; font-size: 1em; font-weight: normal; font-style: normal; opacity: 1; text-anchor: middle;").appendTo($g);
    $g.appendTo($svg);
  }
  // drawLine 
  function drawLine(srcNode, desNode, color) { // tryen vao 1 node
    if (desNode == null) {
      return;
    }
    // tinh toa do
    let idString = "";
    let display = "";
    if (color != "#666") {
      idString = "f" + srcNode.level + srcNode.order + "t" + desNode.level + desNode.order;
      display = "display: none;";
    }
    let xsrc = getXNode(srcNode);
    let ysrc = getYNode(srcNode);
    let xdes = getXNode(desNode);
    let ydes = getYNode(desNode);
    let $svg = $('#svgPanel');
    let $line = $(SVG('path')).attr('d', "M" + xsrc + "," + ysrc + " " + "L" + xdes + "," + ydes).attr("id", idString).attr("style", "stroke:" + color + "; fill:none; stroke-width: 3; " + display + '"');
    $line.appendTo($svg);
    drawNode(srcNode);
  }
  // drawLine Animation
  function drawLineAni(srcNode, desNode) { // ve line
    let idString = "f" + srcNode.level + srcNode.order + "t" + desNode.level + desNode.order;
    $("#" + idString).show();
    let path = document.querySelector("#" + idString);
    let length = path.getTotalLength();
    // Clear any previous transition
    path.style.transition = path.style.WebkitTransition = 'none';
    // Set up the starting positions
    path.style.strokeDasharray = length + ' ' + length;
    path.style.strokeDashoffset = length;
    // Trigger a layout so styles are calculated & the browser
    // picks up the starting position before animating
    path.getBoundingClientRect();
    // Define our transition
    path.style.transition = path.style.WebkitTransition = 'stroke-dashoffset 1s ease-in-out';
    // Go!
    path.style.strokeDashoffset = '0';
  }
  // show node
  function showNode(key) {
    let $svg = $('#svgPanel');
    let $g = $(SVG('g')).attr('transform', "translate(" + 45 + "," + 40 + ")");
    let $circle = $(SVG('circle')).attr('cx', 0).attr('cy', 0).attr('r', 22.5).attr('fill', '#FFF').attr('stroke', '#dd1b16').attr('stroke-width', 3).appendTo($g);
    let $text = $(createText(key)).attr("style", "z-index: 2; fill: #666; font-size: 1em; font-weight: normal; font-style: normal; opacity: 1; text-anchor: middle;").appendTo($g);
    $g.appendTo($svg);
  }
  ////////////////////////////// insert a node //////////////////////////////
  // insert node
  function insertNode(key, tree) {
    $('.log-content').append("<div class='log-item'>START to INSERT node " + key + "</div>");
    showNode(key);
    insertNodeProcess(key, tree);
  }

  function insertNodeProcess(key, tree) {
    drawNode(tree, '#dd1b16');
    let newNode = {};
    if (key < tree.key) { // trai
      $('.log-content').append("<div class='log-item'>" + key + " < " + tree.key + " --> Go to LEFT</div>");
      if (tree.left == null) { // ve node trai
        newNode = {
          key: key,
          level: tree.level + 1,
          order: (2 * tree.order) - 1,
          left: null,
          right: null
        };
        drawLine(tree, newNode, '#dd1b16');
        drawLineAni(tree, newNode);
        setTimeout(function() {
          drawNode(newNode, '#1b72e2');
          $('.log-content').append("<div class='log-item'>Draw Node: " + key + "</div>");
          $('.log-content').append("<div class='log-item'>FINISH</div>");
          return;
        }, 1000);
      } else { // duyet trai
        drawLine(tree, tree.left, '#dd1b16');
        drawLineAni(tree, tree.left);
        setTimeout(function() {
          insertNodeProcess(key, tree.left);
        }, 1000);
      }
    } else { // phai
      $('.log-content').append("<div class='log-item'>" + key + " >= " + tree.key + " --> Go to RIGHT</div>");
      if (tree.right == null) {
        newNode = {
          key: key,
          level: tree.level + 1,
          order: (2 * tree.order),
          left: null,
          right: null
        };
        drawLine(tree, newNode, '#dd1b16');
        drawLineAni(tree, newNode);
        setTimeout(function() {
          drawNode(newNode, '#1b72e2');
          $('.log-content').append("<div class='log-item'>Draw Node: " + key + "</div>");
          $('.log-content').append("<div class='log-item'>FINISH</div>");
          return;
        }, 1000);
      } else {
        drawLine(tree, tree.right, '#dd1b16');
        drawLineAni(tree, tree.right);
        setTimeout(function() {
          insertNodeProcess(key, tree.right);
        }, 1000);
      }
    }
  }
  ////////////////////////////// find a node //////////////////////////////
  function findNode(key, tree) {
    $('.log-content').append("<div class='log-item'>START to FIND node " + key + "</div>");
    showNode(key);
    findNodeProcess(key, tree);
  }

  function findNodeProcess(key, tree) {
    drawNode(tree, '#dd1b16');
    if (key < tree.key) { // trai
      $('.log-content').append("<div class='log-item'>" + key + " < " + tree.key + " --> Go to LEFT</div>");
      if (tree.left == null) { // khong tim thay
        $('.log-content').append("<div class='log-item'>Node " + key + " NOT found</div>");
        $('.log-content').append("<div class='log-item'>FINISH</div>");
        return;
      } else { // duyet trai
        drawLine(tree, tree.left, '#dd1b16');
        drawLineAni(tree, tree.left);
        setTimeout(function() {
          findNodeProcess(key, tree.left);
        }, 1000);
      }
    }
    if (key > tree.key) { // phai
      $('.log-content').append("<div class='log-item'>" + key + " > " + tree.key + " --> Go to RIGHT</div>");
      if (tree.right == null) {
        $('.log-content').append("<div class='log-item'>Node " + key + " NOT found</div>");
        $('.log-content').append("<div class='log-item'>FINISH</div>");
        return;
      } else {
        drawLine(tree, tree.right, '#dd1b16');
        drawLineAni(tree, tree.right);
        setTimeout(function() {
          findNodeProcess(key, tree.right);
        }, 1000);
      }
    }
    if (key == tree.key) { // bang
      $('.log-content').append("<div class='log-item'>" + key + " = " + tree.key + "</div>");
      $('.log-content').append("<div class='log-item'>Node " + key + " was found</div>");
      $('.log-content').append("<div class='log-item'>FINISH</div>");
      drawNode(tree, "#1b72e2");
    }
  }
  ////////////////////////////// Get max //////////////////////////////
  function getMax(tree) {
    $('.log-content').append("<div class='log-item'>START to GET MAX</div>");
    getMaxProcess(tree);
  }

  function getMaxProcess(tree) {
    drawNode(tree, '#dd1b16');
    if (tree.right == null) { // khong tim thay
      drawNode(tree, "#1b72e2");
      $('.log-content').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log-content').append("<div class='log-item'>FINISH</div>");
      return;
    } else { // duyet phai
      $('.log-content').append("<div class='log-item'>Node " + tree.key + " --> Go to RIGHT</div>");
      drawLine(tree, tree.right, '#dd1b16');
      drawLineAni(tree, tree.right);
      setTimeout(function() {
        getMaxProcess(tree.right);
      }, 1000);
    }
  }
  ////////////////////////////// Get min //////////////////////////////
  function getMin(tree) {
    $('.log-content').append("<div class='log-item'>START to GET MIN</div>");
    getMinProcess(tree);
  }

  function getMinProcess(tree) {
    drawNode(tree, '#dd1b16');
    if (tree.left == null) { // khong tim thay
      drawNode(tree, "#1b72e2");
      $('.log-content').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log-content').append("<div class='log-item'>FINISH</div>");
      return;
    } else { // duyet trai
      $('.log-content').append("<div class='log-item'>Node " + tree.key + " --> Go to LEFT</div>");
      drawLine(tree, tree.left, '#dd1b16');
      drawLineAni(tree, tree.left);
      setTimeout(function() {
        getMinProcess(tree.left);
      }, 1000);
    }
  }
  ////////////////////////////// Get min of RIGHT //////////////////////////////
  function getMinOfRight(tree) {
    drawNode(tree, '#dd1b16');
    $('.log-content').append("<div class='log-item'>START to GET MIN of RIGHT</div>");
    if (tree.right == null) {
      drawNode(tree, "#1b72e2");
      $('.log-content').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log-content').append("<div class='log-item'>FINISH</div>");
      return;
    } else {
      drawLine(tree, tree.right, '#dd1b16');
      drawLineAni(tree, tree.right);
      setTimeout(function() {
        getMinProcess(tree.right);
      }, 1000);
    }
  }
  ////////////////////////////// Get max of LEFT //////////////////////////////
  function getMaxOfLeft(tree) {
    drawNode(tree, '#dd1b16');
    $('.log-content').append("<div class='log-item'>START to GET MAX of LEFT</div>");
    if (tree.left == null) {
      drawNode(tree, "#1b72e2");
      $('.log-content').append("<div class='log-item'>Result: " + tree.key + "</div>");
      $('.log-content').append("<div class='log-item'>FINISH</div>");
      return;
    } else {
      drawLine(tree, tree.left, '#dd1b16');
      drawLineAni(tree, tree.left);
      setTimeout(function() {
        getMaxProcess(tree.left);
      }, 1000);
    }
  }
  ////////////////////////////// Get max of Lef //////////////////////////////
  function deleteNode(key, tree) {
    // goi api delete key de tra ve tree
    // sau do goi ham drawTree(tree) de ve lai cay nhe
  }
  ////////////////////////////// Show ORDER //////////////////////////////
  function showOrder(tree, order) {}

  function showOrderLNR(tree) {
    if (tree == null) {
      return;
    }
    showOrderLNR(tree.left);
    $('.log-content').append("<div class='log-item'>" + tree.key + "</div>");
    drawNode(tree, '#dd1b16');
    showOrderLNR(tree.right);
  }

  function showOrderNLR(tree) {
    if (tree == null) {
      return;
    }
    $('.log-content').append("<div class='log-item'>" + tree.key + "</div>");
    drawNode(tree, '#dd1b16');
    showOrderNLR(tree.left);
    showOrderNLR(tree.right);
  }

  function showOrderLRN(tree) {
    if (tree == null) {
      return;
    }
    showOrderLRN(tree.left);
    showOrderLRN(tree.right);
    $('.log-content').append("<div class='log-item'>" + tree.key + "</div>");
    drawNode(tree, '#dd1b16');
  }

  function showTreeInfo(tree) {
    
    getTreeInfo(tree).done(function(data) {
        var treeInfo = data.value;

        $('.tree-info').append("<div class='tree-info-item'>" + "Number of leaves: " + treeInfo.number_of_leaves + "</div>");
        $('.tree-info').append("<div class='tree-info-item'>" + "Nodes have One Child: " + treeInfo.number_of_nodes.having_one_child + "</div>");
        $('.tree-info').append("<div class='tree-info-item'>" + "Nodes have One Left Child: " + treeInfo.number_of_nodes.having_only_left_child  + "</div>");
        $('.tree-info').append("<div class='tree-info-item'>" + "Nodes have One Right Child: " + treeInfo.number_of_nodes.having_only_right_child + "</div>");
        $('.tree-info').append("<div class='tree-info-item'>" + "Nodes have Both Children: " + treeInfo.number_of_nodes.having_both_children + "</div>");
        $('.tree-info').append("<div class='tree-info-item'>" + "Total Nodes: " + treeInfo.number_of_nodes.all + "</div>");
        $('.tree-info').append("<div class='tree-info-item'>" + "Height of Tree: " + treeInfo.height + "</div>");

        var levelStr = "";
        var levels = treeInfo.at_level;
        for (var i = 0; i < levels.length; i++) {
          var levels = treeInfo.at_level
          var s = i + "/" + levels[i];
          levelStr += s + " ";
        }


        $('.tree-info').append("<div class='tree-info-item'>" + "Nodes on each Level (Level/Nodes): " + levelStr + "</div>");
    });



  }
  function clearTree(tree){
    drawTree(tree);
    $('.log-content').empty();
  }
});
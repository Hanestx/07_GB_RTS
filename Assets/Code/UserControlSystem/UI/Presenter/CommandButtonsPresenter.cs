using System;
using System.Collections.Generic;
using UnityEngine;


namespace RTS
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField]private AssetsContext _context;
        
        private ISelectable _currentSelectable;
        
        
        private void Start()
        {
            _selectable.OnSelected += OnSelected;
            OnSelected(_selectable.CurrentValue);
            _view.OnClick += OnButtonClick;
        }

        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
                return;

            _currentSelectable = selectable;
            _view.Clear();
            
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void OnButtonClick(ICommandExecutor commandExecutor)
        {
            if (commandExecutor is CommandExecutorBase<IProduceUnitCommand> produceCommand)
            {
                produceCommand.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }
            
            if (commandExecutor is CommandExecutorBase<IAttackCommand> attackCommand)
            {
                attackCommand.ExecuteSpecificCommand(_context.Inject(new UnitAttackCommand()));
                return;
            }
            
            if (commandExecutor is CommandExecutorBase<IMoveCommand> moveCommand)
            {
                moveCommand.ExecuteSpecificCommand(_context.Inject(new UnitMoveCommand()));
                return;
            }

            if (commandExecutor is CommandExecutorBase<IStopCommand> stopCommand)
            {
                stopCommand.ExecuteSpecificCommand(_context.Inject(new UnitStopCommand()));
                return;
            }
            
            if (commandExecutor is CommandExecutorBase<IPatrolCommand> patrolCommand)
            {
                patrolCommand.ExecuteSpecificCommand(_context.Inject(new UnitPatrolCommand()));
                return;
            }
            
            throw new
                ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)} : " +
                                     $"Unknown type of commands executor:{ commandExecutor.GetType().FullName }!");
        }
    }
}